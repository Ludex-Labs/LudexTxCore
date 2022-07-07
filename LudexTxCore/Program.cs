using Microsoft.Extensions.Logging;
using Solnet.Programs;
using Solnet.Programs.Clients;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Wallet;
using Solnet.Wallet.Utilities;

Console.WriteLine("Hello, World!");

var privkey = new byte[] {  };
var pubkey = "5WTDnoB2HwrQXSLVuw7LuosLfVTPmcZufy53nkE2GA2J";
var pubkeybuf = Encoders.Base58.DecodeData(pubkey);
var acc = new Account(privkey, pubkeybuf);

using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
    .SetMinimumLevel(LogLevel.Trace)
    .AddConsole());

ILogger logger = loggerFactory.CreateLogger("Main");

var rpc = ClientFactory.GetClient(Cluster.DevNet, logger);

var client = new SplWagerClient(rpc, false);
var challenge = new PublicKey("B2JcpUu1QwiCcZgoK6HUVTjGd7TpuSBQtL33zfsAmYcH");

//SendMyself(acc, 600000);
var res = await client.JoinAsync(acc, challenge);

Console.WriteLine($"joining challengeId: {challenge} with {acc.PublicKey}");

if (res.WasSuccessful)
{
    Console.WriteLine(res.Result);
}
else
{
    Console.WriteLine(res.Reason);
}


Console.ReadLine();

async void SendMyself(Account account, ulong amount)
{
    var balance = await rpc.GetBalanceAsync(account.PublicKey.Key);

    logger.LogInformation($"Account has {balance}");
    Console.WriteLine($"transfering {amount} wrapped sol from {account.PublicKey} to {account.PublicKey}");

    var blockHash = await rpc.GetLatestBlockHashAsync();
    byte[] createAssociatedTokenAccountTx = new TransactionBuilder().
        SetRecentBlockHash(blockHash.Result.Value.Blockhash).
        SetFeePayer(account.PublicKey).
        AddInstruction(SystemProgram.Transfer(
            account.PublicKey,
            new PublicKey("FZYUeuZiTfsZQyW6GQM87BfPD8V3Xo1DTEpGihV8UEKc"),
            amount)).
        AddInstruction(TokenProgram.SyncNative(new PublicKey("FZYUeuZiTfsZQyW6GQM87BfPD8V3Xo1DTEpGihV8UEKc"))).
        Build(new List<Account> { account });

    Console.WriteLine($"Tx base64: {Convert.ToBase64String(createAssociatedTokenAccountTx)}");

    var txSim = rpc.SimulateTransaction(createAssociatedTokenAccountTx);
    Console.WriteLine(string.Join(',', txSim.Result.Value.Logs));
    var res2 = await rpc.SendTransactionAsync(createAssociatedTokenAccountTx);
    EnsureSuccess(res2);
    Console.WriteLine(res2.Result);
}

static void EnsureSuccess<T>(RequestResult<T> result)
{
    if (!result.WasSuccessful)
    {
        throw new Exception($"Request failure: { result.Reason }");
    }
}