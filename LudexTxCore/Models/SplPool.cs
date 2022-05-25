using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.Models
{
    public class SplPool
    {
        public static class Layout
        {
            public const int Length = 8 + 32 + 32 + 32 + 32 + 100;

            public const int ProviderOffset = 8;
            public const int TokenAccountOffset = 8 + 32;
            public const int PayoutTokenAccountOffset = 8 + 32 + 32;
            public const int MintOffset = 8 + 32 + 32 + 32;
        }

        public PublicKey Provider { get; set; }
        public PublicKey TokenAccount { get; set; }
        public PublicKey PayoutTokenAccount { get; set; }
        public PublicKey Mint { get; set; }

        public static SplPool Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException(
                    $"{nameof(data)} has wrong size. Expected {Layout.Length} bytes, actual {data.Length} bytes.");

            var res = new SplPool
            {
                Provider = data.GetPubKey(Layout.ProviderOffset),
                TokenAccount = data.GetPubKey(Layout.TokenAccountOffset),
                PayoutTokenAccount = data.GetPubKey(Layout.PayoutTokenAccountOffset),
                Mint = data.GetPubKey(Layout.MintOffset),
            };

            return res;
        }
    }
}
