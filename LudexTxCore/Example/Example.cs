using Solnet.Rpc;
using Solnet.Wallet;


namespace Ludex.Client.Examples
{
    public class Example
    {
        private const string MnemonicWords =
            "route clerk disease box emerge airport loud waste attitude film army tray " +
            "forward deal onion eight catalog surface unit card window walnut wealth medal";

        public async void Run()
        {
            Wallet wallet = new Wallet(MnemonicWords);
            var rpc = ClientFactory.GetClient(Cluster.MainNet);
            
            var client = new SPLChallengeClient(rpc, false);
            var challenge = new PublicKey("<challenge pubkey>");
            var res = await client.JoinAsync(wallet, challenge);
        }
    }
}