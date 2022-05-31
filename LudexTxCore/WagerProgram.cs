// ================================================================================= //
// This file was generated with Solnet.Anchor.Tool with minor modifications
// Get the tool https://github.com/bmresearch/Solnet.Anchor to update this file
// ================================================================================= //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Wallet;
using Challenge;
using Challenge.Program;
using Challenge.Errors;
using Challenge.Accounts;
using Challenge.Types;

namespace Challenge
{
    namespace Accounts
    {
        public partial class Provider
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 14073986652456858788UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{164, 180, 71, 17, 75, 216, 80, 195};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "UYqZAeAaShQ";
            public PublicKey Authority { get; set; }

            public byte Bump { get; set; }

            public static Provider Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Provider result = new Provider();
                result.Authority = _data.GetPubKey(offset);
                offset += 32;
                result.Bump = _data.GetU8(offset);
                offset += 1;
                return result;
            }
        }

        public partial class Pool
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 13577703138238765809UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{241, 154, 109, 4, 17, 177, 109, 188};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "hQrXeCntzbV";
            public PublicKey Provider { get; set; }

            public PublicKey TokenAccount { get; set; }

            public PublicKey PayoutTokenAccount { get; set; }

            public PublicKey Mint { get; set; }

            public static Pool Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Pool result = new Pool();
                result.Provider = _data.GetPubKey(offset);
                offset += 32;
                result.TokenAccount = _data.GetPubKey(offset);
                offset += 32;
                result.PayoutTokenAccount = _data.GetPubKey(offset);
                offset += 32;
                result.Mint = _data.GetPubKey(offset);
                offset += 32;
                return result;
            }
        }

        public partial class Challenge
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 14994261582960261751UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{119, 250, 161, 121, 119, 81, 22, 208};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "M4wvCQBurj9";
            public PublicKey Provider { get; set; }

            public PublicKey Pool { get; set; }

            public PublicKey Mediator { get; set; }

            public bool Locked { get; set; }

            public ulong EntryFee { get; set; }

            public byte PlayersLimit { get; set; }

            public byte PlayersJoined { get; set; }

            public ulong MediatorRake { get; set; }

            public ulong ProviderRake { get; set; }

            public byte Expected { get; set; }

            public byte ExpectedCreated { get; set; }

            public byte ExpectedJoined { get; set; }

            public static Challenge Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Challenge result = new Challenge();
                result.Provider = _data.GetPubKey(offset);
                offset += 32;
                result.Pool = _data.GetPubKey(offset);
                offset += 32;
                result.Mediator = _data.GetPubKey(offset);
                offset += 32;
                result.Locked = _data.GetBool(offset);
                offset += 1;
                result.EntryFee = _data.GetU64(offset);
                offset += 8;
                result.PlayersLimit = _data.GetU8(offset);
                offset += 1;
                result.PlayersJoined = _data.GetU8(offset);
                offset += 1;
                result.MediatorRake = _data.GetU64(offset);
                offset += 8;
                result.ProviderRake = _data.GetU64(offset);
                offset += 8;
                result.Expected = _data.GetU8(offset);
                offset += 1;
                result.ExpectedCreated = _data.GetU8(offset);
                offset += 1;
                result.ExpectedJoined = _data.GetU8(offset);
                offset += 1;
                return result;
            }
        }

        public partial class Player
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 15766710478567431885UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{205, 222, 112, 7, 165, 155, 206, 218};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "bSBoKNsSHuj";
            public PublicKey Challenge { get; set; }

            public byte Bump { get; set; }

            public PublicKey Auth { get; set; }

            public PublicKey TokenAccount { get; set; }

            public ulong Amount { get; set; }

            public static Player Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Player result = new Player();
                result.Challenge = _data.GetPubKey(offset);
                offset += 32;
                result.Bump = _data.GetU8(offset);
                offset += 1;
                result.Auth = _data.GetPubKey(offset);
                offset += 32;
                result.TokenAccount = _data.GetPubKey(offset);
                offset += 32;
                result.Amount = _data.GetU64(offset);
                offset += 8;
                return result;
            }
        }

        public partial class Payments
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 2478981951559154348UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{172, 186, 73, 99, 243, 28, 103, 34};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "Vtg9KQoCf2R";
            public PublicKey Payer { get; set; }

            public PublicKey Challenge { get; set; }

            public Payment[] PaymentList { get; set; }

            public bool Verified { get; set; }

            public ulong Total { get; set; }

            public byte SelfBump { get; set; }

            public static Payments Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                Payments result = new Payments();
                result.Payer = _data.GetPubKey(offset);
                offset += 32;
                result.Challenge = _data.GetPubKey(offset);
                offset += 32;
                uint resultPaymentsLength = _data.GetU32(offset);
                offset += 4;
                result.PaymentList = new Payment[resultPaymentsLength];
                for (uint resultPaymentsIdx = 0; resultPaymentsIdx < resultPaymentsLength; resultPaymentsIdx++)
                {
                    offset += Payment.Deserialize(_data, offset, out var resultPaymentsresultPaymentsIdx);
                    result.PaymentList[resultPaymentsIdx] = resultPaymentsresultPaymentsIdx;
                }

                result.Verified = _data.GetBool(offset);
                offset += 1;
                result.Total = _data.GetU64(offset);
                offset += 8;
                result.SelfBump = _data.GetU8(offset);
                offset += 1;
                return result;
            }
        }

        public partial class ExpectedPlayer
        {
            public static ulong ACCOUNT_DISCRIMINATOR => 14550993876877384734UL;
            public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[]{30, 28, 41, 40, 214, 131, 239, 201};
            public static string ACCOUNT_DISCRIMINATOR_B58 => "6375NNMPwKE";
            public PublicKey Challenge { get; set; }

            public PublicKey Player { get; set; }

            public byte SelfBump { get; set; }

            public static ExpectedPlayer Deserialize(ReadOnlySpan<byte> _data)
            {
                int offset = 0;
                ulong accountHashValue = _data.GetU64(offset);
                offset += 8;
                if (accountHashValue != ACCOUNT_DISCRIMINATOR)
                {
                    return null;
                }

                ExpectedPlayer result = new ExpectedPlayer();
                result.Challenge = _data.GetPubKey(offset);
                offset += 32;
                result.Player = _data.GetPubKey(offset);
                offset += 32;
                result.SelfBump = _data.GetU8(offset);
                offset += 1;
                return result;
            }
        }
    }

    namespace Errors
    {
        public enum ChallengeErrorKind : uint
        {
            Unauthorized = 6000U,
            NonExaustiveRemainingAccounts = 6001U,
            DifferentScale = 6002U,
            PayoutMissmatch = 6003U,
            MediatorPayoutMissmatch = 6004U,
            ProviderPayoutMissmatch = 6005U,
            LockedChallenge = 6006U,
            UnlockedChallenge = 6007U,
            ChallengeInactive = 6008U,
            ChallengeFull = 6009U,
            InsufficientFunds = 6010U,
            HeaderMissmatch = 6011U,
            NotPaid = 6012U,
            InvalidPool = 6013U,
            InvalidChallenge = 6014U,
            InvalidMint = 6015U,
            InvalidMediator = 6016U,
            AlreadyJoined = 6017U,
            AlreadyVerified = 6018U,
            SuperAdmin = 6019U,
            ExpectedIssue = 6020U,
            ChallengeExpectedPlayerFull = 6021U,
            NeedToBeExpectedPlayer = 6022U,
            ExpectedPlayerNotInChallenge = 6023U,
            ExpectedPlayerNotProvidedToJoin = 6024U,
            VerifyPayment = 6025U
        }
    }

    namespace Types
    {
        public partial class Payment
        {
            public PublicKey Player { get; set; }

            public ulong Amount { get; set; }

            public bool Verified { get; set; }

            public bool Paid { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WritePubKey(Player, offset);
                offset += 32;
                _data.WriteU64(Amount, offset);
                offset += 8;
                _data.WriteBool(Verified, offset);
                offset += 1;
                _data.WriteBool(Paid, offset);
                offset += 1;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out Payment result)
            {
                int offset = initialOffset;
                result = new Payment();
                result.Player = _data.GetPubKey(offset);
                offset += 32;
                result.Amount = _data.GetU64(offset);
                offset += 8;
                result.Verified = _data.GetBool(offset);
                offset += 1;
                result.Paid = _data.GetBool(offset);
                offset += 1;
                return offset - initialOffset;
            }
        }

        public partial class PaymentArg
        {
            public PublicKey Player { get; set; }

            public ulong Amount { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WritePubKey(Player, offset);
                offset += 32;
                _data.WriteU64(Amount, offset);
                offset += 8;
                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PaymentArg result)
            {
                int offset = initialOffset;
                result = new PaymentArg();
                result.Player = _data.GetPubKey(offset);
                offset += 32;
                result.Amount = _data.GetU64(offset);
                offset += 8;
                return offset - initialOffset;
            }
        }

        public partial class PaymentArgAcc
        {
            public PaymentArg[] Payments { get; set; }

            public int Serialize(byte[] _data, int initialOffset)
            {
                int offset = initialOffset;
                _data.WriteS32(Payments.Length, offset);
                offset += 4;
                foreach (var paymentsElement in Payments)
                {
                    offset += paymentsElement.Serialize(_data, offset);
                }

                return offset - initialOffset;
            }

            public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out PaymentArgAcc result)
            {
                int offset = initialOffset;
                result = new PaymentArgAcc();
                uint resultPaymentsLength = _data.GetU32(offset);
                offset += 4;
                result.Payments = new PaymentArg[resultPaymentsLength];
                for (uint resultPaymentsIdx = 0; resultPaymentsIdx < resultPaymentsLength; resultPaymentsIdx++)
                {
                    offset += PaymentArg.Deserialize(_data, offset, out var resultPaymentsresultPaymentsIdx);
                    result.Payments[resultPaymentsIdx] = resultPaymentsresultPaymentsIdx;
                }

                return offset - initialOffset;
            }
        }
    }

    public partial class ChallengeClient : TransactionalBaseClient<ChallengeErrorKind>
    {
        public ChallengeClient(IRpcClient rpcClient, IStreamingRpcClient streamingRpcClient, PublicKey programId) : base(rpcClient, streamingRpcClient, programId)
        {
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Provider>>> GetProvidersAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Provider.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Provider>>(res);
            List<Provider> resultingAccounts = new List<Provider>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Provider.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Provider>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Pool>>> GetPoolsAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Pool.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Pool>>(res);
            List<Pool> resultingAccounts = new List<Pool>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Pool.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Pool>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Accounts.Challenge>>> GetChallengesAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Accounts.Challenge.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Accounts.Challenge>>(res);
            List<Accounts.Challenge> resultingAccounts = new List<Accounts.Challenge>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Accounts.Challenge.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Accounts.Challenge>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Player>>> GetPlayersAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Player.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Player>>(res);
            List<Player> resultingAccounts = new List<Player>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Player.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Player>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Payments>>> GetPaymentssAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = Payments.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Payments>>(res);
            List<Payments> resultingAccounts = new List<Payments>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Payments.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<Payments>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ExpectedPlayer>>> GetExpectedPlayersAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp>{new Solnet.Rpc.Models.MemCmp{Bytes = ExpectedPlayer.ACCOUNT_DISCRIMINATOR_B58, Offset = 0}};
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ExpectedPlayer>>(res);
            List<ExpectedPlayer> resultingAccounts = new List<ExpectedPlayer>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => ExpectedPlayer.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new Solnet.Programs.Models.ProgramAccountsResultWrapper<List<ExpectedPlayer>>(res, resultingAccounts);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Provider>> GetProviderAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Provider>(res);
            var resultingAccount = Provider.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Provider>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Pool>> GetPoolAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Pool>(res);
            var resultingAccount = Pool.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Pool>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Accounts.Challenge>> GetChallengeAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Accounts.Challenge>(res);
            var resultingAccount = Accounts.Challenge.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Accounts.Challenge>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Player>> GetPlayerAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Player>(res);
            var resultingAccount = Player.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Player>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<Payments>> GetPaymentsAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<Payments>(res);
            var resultingAccount = Payments.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<Payments>(res, resultingAccount);
        }

        public async Task<Solnet.Programs.Models.AccountResultWrapper<ExpectedPlayer>> GetExpectedPlayerAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new Solnet.Programs.Models.AccountResultWrapper<ExpectedPlayer>(res);
            var resultingAccount = ExpectedPlayer.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new Solnet.Programs.Models.AccountResultWrapper<ExpectedPlayer>(res, resultingAccount);
        }

        public async Task<SubscriptionState> SubscribeProviderAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Provider> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Provider parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Provider.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribePoolAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Pool> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Pool parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Pool.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeChallengeAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Accounts.Challenge> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Accounts.Challenge parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Accounts.Challenge.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribePlayerAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Player> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Player parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Player.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribePaymentsAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Payments> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Payments parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Payments.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeExpectedPlayerAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, ExpectedPlayer> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                ExpectedPlayer parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = ExpectedPlayer.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<RequestResult<string>> SendJoinAsync(JoinAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ChallengeProgram.Join(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendLeaveAsync(LeaveAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = Program.ChallengeProgram.Leave(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        protected override Dictionary<uint, ProgramError<ChallengeErrorKind>> BuildErrorsDictionary()
        {
            return new Dictionary<uint, ProgramError<ChallengeErrorKind>>{{6000U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.Unauthorized, "You are not admin for this provider")}, {6001U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.NonExaustiveRemainingAccounts, "Not all player accounts are present")}, {6002U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.DifferentScale, "Scale is different")}, {6003U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.PayoutMissmatch, "Payout doesn't match")}, {6004U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.MediatorPayoutMissmatch, "Payout for mediator is incorrect")}, {6005U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ProviderPayoutMissmatch, "Payout for provider is incorrect")}, {6006U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.LockedChallenge, "Challenge Locked")}, {6007U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.UnlockedChallenge, "Cannot resolve unlocked Challenge")}, {6008U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ChallengeInactive, "Challenge is no longer tracked")}, {6009U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ChallengeFull, "Challenge is full")}, {6010U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.InsufficientFunds, "Insufficient funds")}, {6011U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.HeaderMissmatch, "Challenge Header Missmatch")}, {6012U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.NotPaid, "Can't close until all paid")}, {6013U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.InvalidPool, "Pool is not in provider")}, {6014U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.InvalidChallenge, "Invalid Challenge")}, {6015U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.InvalidMint, "Invalid Mint")}, {6016U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.InvalidMediator, "Invalid Mediator")}, {6017U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.AlreadyJoined, "Already Joined")}, {6018U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.AlreadyVerified, "Already Verified")}, {6019U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.SuperAdmin, "Not Super Admin")}, {6020U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ExpectedIssue, "Expected higher than possible")}, {6021U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ChallengeExpectedPlayerFull, "Challenge already reached expected player")}, {6022U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.NeedToBeExpectedPlayer, "Need to be expected player to join challenge")}, {6023U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ExpectedPlayerNotInChallenge, "Expected player not part of challenge")}, {6024U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.ExpectedPlayerNotProvidedToJoin, "Expected player not provided on join")}, {6025U, new ProgramError<ChallengeErrorKind>(ChallengeErrorKind.VerifyPayment, "Payment needs to be verified")}, };
        }
    }

    namespace Program
    {
        public class JoinAccounts
        {
            public PublicKey Provider { get; set; }

            public PublicKey Pool { get; set; }

            public PublicKey PoolTokenAccount { get; set; }

            public PublicKey Challenge { get; set; }

            public PublicKey Player { get; set; }

            public PublicKey Payer { get; set; }

            public PublicKey ProviderAuthority { get; set; }

            public PublicKey User { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey Mint { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public class LeaveAccounts
        {
            public PublicKey Provider { get; set; }

            public PublicKey Pool { get; set; }

            public PublicKey PoolTokenAccount { get; set; }

            public PublicKey Challenge { get; set; }

            public PublicKey Player { get; set; }

            public PublicKey User { get; set; }

            public PublicKey UserTokenAccount { get; set; }

            public PublicKey Mint { get; set; }

            public PublicKey TokenProgram { get; set; }

            public PublicKey SystemProgram { get; set; }
        }

        public static class ChallengeProgram
        {
            public static Solnet.Rpc.Models.TransactionInstruction Join(JoinAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Provider, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Pool, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.PoolTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Challenge, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Player, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Payer, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.ProviderAuthority, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.User, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Mint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(11750415282454280142UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }

            public static Solnet.Rpc.Models.TransactionInstruction Leave(LeaveAccounts accounts, PublicKey programId)
            {
                List<Solnet.Rpc.Models.AccountMeta> keys = new()
                {Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Provider, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Pool, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.PoolTokenAccount, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.Challenge, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Player, false), Solnet.Rpc.Models.AccountMeta.Writable(accounts.User, true), Solnet.Rpc.Models.AccountMeta.Writable(accounts.UserTokenAccount, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.Mint, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.TokenProgram, false), Solnet.Rpc.Models.AccountMeta.ReadOnly(accounts.SystemProgram, false)};
                byte[] _data = new byte[1200];
                int offset = 0;
                _data.WriteU64(8119309991834610235UL, offset);
                offset += 8;
                byte[] resultData = new byte[offset];
                Array.Copy(_data, resultData, offset);
                return new Solnet.Rpc.Models.TransactionInstruction{Keys = keys, ProgramId = programId.KeyBytes, Data = resultData};
            }
            
        }
    }
}
