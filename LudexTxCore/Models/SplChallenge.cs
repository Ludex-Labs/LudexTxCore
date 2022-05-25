using Solnet.Programs.Utilities;
using Solnet.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solnet.Programs.Models
{
    public class SplChallenge
    {
        public static class Layout
        {
            public const int Length = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1 + 8 + 8 + 100;

            public const int ProviderOffset = 8;
            public const int PoolOffset = 8 + 32;
            public const int MediatorOffset = 8 + 32 + 32;
            public const int LockedOffset = 8 + 32 + 32 + 32;
            public const int EntryFeeOffset = 8 + 32 + 32 + 32 + 1;
            public const int PlayersLimitOffset = 8 + 32 + 32 + 32 + 1 + 8;
            public const int PlayersJoinedOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1;
            public const int MediatorRakeOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1;
            public const int ProviderRakeOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1 + 8;
            public const int ExpectedOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1 + 8 + 8;
            public const int ExpectedCreatedOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1 + 8 + 1;
            public const int ExpectedJoinedOffset = 8 + 32 + 32 + 32 + 1 + 8 + 1 + 1 + 8 + 1 + 1;
        }

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

        public static SplChallenge Deserialize(ReadOnlySpan<byte> data)
        {
            if (data.Length != Layout.Length)
                throw new ArgumentException(
                    $"{nameof(data)} has wrong size. Expected {Layout.Length} bytes, actual {data.Length} bytes.");

            var res = new SplChallenge
            {
                Provider = data.GetPubKey(Layout.ProviderOffset),
                Pool = data.GetPubKey(Layout.PoolOffset),
                Mediator = data.GetPubKey(Layout.MediatorOffset),
                Locked = data.GetBool(Layout.LockedOffset),
                EntryFee = data.GetU64(Layout.EntryFeeOffset),
                PlayersLimit = data.GetU8(Layout.PlayersLimitOffset),
                PlayersJoined = data.GetU8(Layout.PlayersJoinedOffset),
                MediatorRake = data.GetU64(Layout.MediatorRakeOffset),
                ProviderRake = data.GetU64(Layout.ProviderRakeOffset),
                Expected = data.GetU8(Layout.ExpectedOffset),
                ExpectedCreated = data.GetU8(Layout.ExpectedCreatedOffset),
                ExpectedJoined = data.GetU8(Layout.ExpectedJoinedOffset),
            };


            return res;
        }
    }
}
