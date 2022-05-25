using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Wallet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solnet.Programs
{
    public static class SplWagerProgram
    {
        public static readonly PublicKey ProgramIdKeyDevnet = new("CoiJYvDgj8BqQr8MEBjyXKfsQFrYQSYdwEuzjivE2D7");
        public static readonly PublicKey ProgramIdKeyMainnet = new("BuPvutSnk9NdTZHFiA6UZm6oPwGszp6ozMwoAgJMDBGR");

        public static TransactionInstruction Join(PublicKey provider, PublicKey pool, PublicKey poolTokenAccount, PublicKey challenge, PublicKey providerAuthority, PublicKey user, PublicKey userTokenAccount, PublicKey mint, bool isMainnet)
        {
            PublicKey playerAddress = DerivePlayerAccountAddress(challenge, user, isMainnet);
            List<AccountMeta> keys = new()
            {
                // provider
                AccountMeta.ReadOnly(provider, false),
                // pool
                AccountMeta.ReadOnly(pool, false),
                // pool token account
                AccountMeta.Writable(poolTokenAccount, false),
                // challenge
                AccountMeta.Writable(challenge, false),
                // player
                AccountMeta.Writable(playerAddress, true),
                // payer
                AccountMeta.Writable(user, true),
                // provider_authority
                AccountMeta.Writable(providerAuthority, false),
                // user
                AccountMeta.Writable(user, true), 
                // user_token_account
                AccountMeta.Writable(userTokenAccount, false),
                // mint
                AccountMeta.ReadOnly(mint, false),
                // token_program
                AccountMeta.ReadOnly(TokenProgram.ProgramIdKey, false),
                // SystemProgram
                AccountMeta.ReadOnly(SystemProgram.ProgramIdKey, false),
            };

            return new TransactionInstruction
            {
                ProgramId = isMainnet ? ProgramIdKeyMainnet.KeyBytes : ProgramIdKeyDevnet.KeyBytes,
                Keys = keys,
                Data = Array.Empty<byte>()
            };
        }

        private static PublicKey DerivePlayerAccountAddress(PublicKey challenge, PublicKey user, bool isMainnet)
        {
            bool success = PublicKey.TryFindProgramAddress(
                new List<byte[]> { challenge.KeyBytes, user.KeyBytes },
                isMainnet ? ProgramIdKeyMainnet : ProgramIdKeyDevnet, out PublicKey derivedPlayerAccountAddress, out _);
            return derivedPlayerAccountAddress;
        }
        
    }
}

