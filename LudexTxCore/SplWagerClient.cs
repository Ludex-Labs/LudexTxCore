
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
    public class SplWagerClient: BaseClient
    {
        private bool isMainnet;
        public SplWagerClient(IRpcClient rpcClient, bool isMainnet) : base(rpcClient, null, isMainnet ? SplWagerProgram.ProgramIdKeyMainnet : SplWagerProgram.ProgramIdKeyDevnet)
        {
            this.isMainnet = isMainnet;
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
                    SplWagerProgram.Join(
                        challenge.Provider, 
                        challenge.Pool, 
                        pool.TokenAccount, 
                        challengeKey, 
                        provider.Authority, 
                        wallet.PublicKey, 
                        ata, 
                        pool.Mint, 
                        isMainnet
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
    }
}
