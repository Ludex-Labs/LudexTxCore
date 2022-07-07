
using Solnet.Programs.Abstract;
using Solnet.Programs.Models;
using Solnet.Programs.Models.NameService;
using Solnet.Rpc;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solnet.Extensions;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Messages;

namespace Solnet.Programs.Clients
{
    public class SplWagerClient : BaseClient
    {
        public PublicKey WagerProgramKeyId;

        public SplWagerClient(IRpcClient rpcClient, bool isMainnet) : base(rpcClient, null, GetProgramKeyId(isMainnet))
        {
            WagerProgramKeyId = GetProgramKeyId(isMainnet);
        }

        public async Task<SplChallenge> GetChallengeAsync(PublicKey challenge)
        {
            var res = await RpcClient.GetAccountInfoAsync(challenge);
            var data = Convert.FromBase64String(res.Result.Value.Data[0]);
            return SplChallenge.Deserialize(data);
        }

        public async Task<SplPool> GetPoolAsync(PublicKey pool)
        {
            var res = await RpcClient.GetAccountInfoAsync(pool);
            var data = Convert.FromBase64String(res.Result.Value.Data[0]);
            return SplPool.Deserialize(data);
        }

        public async Task<SplProvider> GetProviderAsync(PublicKey provider)
        {
            var res = await RpcClient.GetAccountInfoAsync(provider);
            var data = Convert.FromBase64String(res.Result.Value.Data[0]);
            return SplProvider.Deserialize(data);
        }

        public async Task<RequestResult<string>> JoinAsync(Account wallet, PublicKey challengeKey)
        {
            var challenge = await GetChallengeAsync(challengeKey);
            var pool = await GetPoolAsync(challenge.Pool);
            var provider = await GetProviderAsync(challenge.Provider);
            var ata = await GetAta(wallet, pool.Mint, challenge.EntryFee);
            var blockHash = await RpcClient.GetLatestBlockHashAsync();
            byte[] tx = new TransactionBuilder()
                .SetRecentBlockHash(blockHash.Result.Value.Blockhash)
                .SetFeePayer(wallet)
                .AddInstruction(
                    Challenge.Program.ChallengeProgram.Join(
                        new Challenge.Program.JoinAccounts 
                        { 
                            Provider = challenge.Provider,
                            Pool = challenge.Pool,
                            PoolTokenAccount = pool.TokenAccount,
                            Challenge = challengeKey,
                            ProviderAuthority = provider.Authority,
                            UserTokenAccount = ata,
                            Mint = pool.Mint,
                            User = wallet,
                            Payer = wallet,
                            Player = DerivePlayerAccountAddress(challengeKey, wallet),
                            SystemProgram = SystemProgram.ProgramIdKey,
                            TokenProgram = TokenProgram.ProgramIdKey,
                        },
                        WagerProgramKeyId
                        ))
                .Build(new List<Account> { wallet });

            RequestResult<string> sig = await RpcClient.SendTransactionAsync(tx);
            return sig;
        }

        public async Task<PublicKey> GetAta(Account wallet, PublicKey mint, ulong amount)
        {
            PublicKey associatedTokenAccount =
                AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(wallet.PublicKey, mint);

            var res = RpcClient.GetTokenAccountBalanceAsync(associatedTokenAccount.Key);
            if (!res.Result.WasSuccessful && mint == WellKnownTokens.WrappedSOL.TokenMint)
            {
                var balance = RpcClient.GetBalanceAsync(wallet.PublicKey.Key);
                if (balance.Result.Result.Value < amount)
                {
                    throw new Exception("You need " + (balance.Result.Result.Value - amount) + " more sol");
                }
                var blockHash = await RpcClient.GetLatestBlockHashAsync();

                byte[] createAssociatedTokenAccountTx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(wallet).
                    AddInstruction(AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(
                        wallet.PublicKey,
                       associatedTokenAccount,
                        mint)).
                    AddInstruction(SystemProgram.Transfer(
                        wallet.PublicKey,
                        associatedTokenAccount,
                        amount)).
                    AddInstruction(TokenProgram.SyncNative(associatedTokenAccount)).
                    Build(new List<Account> { wallet });

                await RpcClient.SendTransactionAsync(createAssociatedTokenAccountTx);
            }
            else if (mint == WellKnownTokens.WrappedSOL.TokenMint)
            {
                var balance = RpcClient.GetBalanceAsync(wallet.PublicKey.Key);
                if (balance.Result.Result.Value + res.Result.Result.Value.AmountUlong < amount)
                {
                    throw new Exception("You need " + (balance.Result.Result.Value + res.Result.Result.Value.AmountUlong - amount) + " more sol");
                }
                var blockHash = await RpcClient.GetLatestBlockHashAsync();
                byte[] createAssociatedTokenAccountTx = new TransactionBuilder().
                    SetRecentBlockHash(blockHash.Result.Value.Blockhash).
                    SetFeePayer(wallet).
                    AddInstruction(SystemProgram.Transfer(
                        wallet.PublicKey,
                        associatedTokenAccount,
                        amount)).
                    AddInstruction(TokenProgram.SyncNative(associatedTokenAccount)).
                    Build(new List<Account> { wallet });

                await RpcClient.SendTransactionAsync(createAssociatedTokenAccountTx);
            }
            else if (res.Result.Result.Value.AmountUlong < amount)
            {
                throw new Exception("You need " + (res.Result.Result.Value.AmountUlong - amount) + " more tokens");
            }

            return associatedTokenAccount;
        }

        public PublicKey DerivePlayerAccountAddress(PublicKey challenge, PublicKey user)
        {
            bool success = PublicKey.TryFindProgramAddress(
                new List<byte[]> { challenge.KeyBytes, user.KeyBytes },
                WagerProgramKeyId, out PublicKey derivedPlayerAccountAddress, out _);
            return derivedPlayerAccountAddress;
        }

        private static PublicKey GetProgramKeyId(bool isMainnet)
        {
            return new PublicKey(isMainnet ? "BuPvutSnk9NdTZHFiA6UZm6oPwGszp6ozMwoAgJMDBGR" : "CoiJYvDgj8BqQr8MEBjyXKfsQFrYQSYdwEuzjivE2D7");
        }
    }
}
