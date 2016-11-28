using System;

using CryptoBuilder.Crypto.Prng.Drbg;

namespace CryptoBuilder.Crypto.Prng
{
    internal interface IDrbgProvider
    {
        ISP80090Drbg Get(IEntropySource entropySource);
    }
}
