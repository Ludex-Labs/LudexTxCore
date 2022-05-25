using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.Models
{
    public class SplProvider
    {
        public static class Layout
        {
            public const int Length = 8 + 32 + 1 + 100;

            public const int AuthorityOffset = 8;
            public const int BumpOffset = 8 + 32;
        }

        public PublicKey Authority { get; set; }
        public byte Bump { get; set; }

        public static SplProvider Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException(
                    $"{nameof(data)} has wrong size. Expected {Layout.Length} bytes, actual {data.Length} bytes.");

            var res = new SplProvider
            {
                Authority = data.GetPubKey(Layout.AuthorityOffset),
                Bump = data.GetU8(Layout.BumpOffset),
            };

            return res;
        }
    }
}
