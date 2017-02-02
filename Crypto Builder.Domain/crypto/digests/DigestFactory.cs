using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBuilder.Crypto.Digests
{
    public static class DigestFactory
    {
       public static IDictionary<string, Type> Digests;

        static DigestFactory()
        {
            Digests = new Dictionary<string, Type> 
            {
                {"GOST3411", typeof(Gost3411Digest) },
                {"Keccak", typeof(KeccakDigest) },
                {"MD2", typeof(MD2Digest) },
                {"MD4", typeof(MD4Digest) },
                {"MD5", typeof(MD5Digest) },
                {"RipeMD128", typeof(RipeMD128Digest) },
                {"RipeMD160", typeof(RipeMD160Digest) },
                {"RipeMD256", typeof(RipeMD256Digest) },
                {"RipeMD320", typeof(RipeMD320Digest) },
                {"Sha1", typeof(Sha1Digest) },
                {"Sha224", typeof(Sha224Digest) },
                {"Sha384", typeof(Sha384Digest) },
                {"Sha512", typeof(Sha512Digest) },
                {"Shake", typeof(ShakeDigest) },
                {"Skein", typeof(SkeinDigest) },
                {"SM3", typeof(SM3Digest) },
                {"Tiger", typeof(TigerDigest) },
                {"Whirlpool", typeof(WhirlpoolDigest) }
            }; 
        }

        public static IDigest CreateDigets(string name)
        {
            if (!Digests.ContainsKey(name))
                throw new Exception("Cannot create digest algorithm!");

            IDigest digest = (IDigest)Activator.CreateInstance(Digests[name]);

            return digest; 
        }
    }
}
