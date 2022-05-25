using Solnet.Programs.Clients;
using Solnet.Rpc;
using System;
using Solnet.Wallet;


namespace Solnet.Examples
{
    public class Example
    {
        private static readonly IRpcClient RpcClient = ClientFactory.GetClient(Cluster.DevNet);

        private const string MnemonicWords =
            "route clerk disease box emerge airport loud waste attitude film army tray " +
            "forward deal onion eight catalog surface unit card window walnut wealth medal";

        public async void Run()
        {
            Wallet.Wallet wallet = new Wallet.Wallet(MnemonicWords);
            var rpc = ClientFactory.GetClient(Cluster.MainNet);
            
            var client = new SplWagerClient(rpc, false);
            var challenge = new PublicKey("<challenge pubkey>");
            var res = await client.JoinAsync(wallet, challenge);
        }
    }

}
