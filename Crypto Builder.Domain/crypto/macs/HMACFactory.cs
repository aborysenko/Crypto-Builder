using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Digests;
using CryptoBuilder.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBuilder.crypto.macs
{
    public static class HMACFactory
    {
        public static IDictionary<string, Type> Hmacs;

        static HMACFactory()
        {
            Hmacs = new Dictionary<string, Type>
            {
                {"HMACMD2", typeof(MD2Digest) },
                {"HMACMD4", typeof(MD4Digest) },
                {"HMACMD5", typeof(MD5Digest) }
            };
        }

        public static IMac CreateDigets(string name)
        {
            if (!Hmacs.ContainsKey(name))
                throw new Exception("Cannot create hmac algorithm!");

            IDigest digest = (IDigest)Activator.CreateInstance(Hmacs[name]);

            var hmac = new HMac(digest);

            return hmac;
        }
    }
}
