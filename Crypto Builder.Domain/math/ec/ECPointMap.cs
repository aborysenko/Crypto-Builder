using System;

namespace CryptoBuilder.Math.EC
{
    public interface ECPointMap
    {
        ECPoint Map(ECPoint p);
    }
}
