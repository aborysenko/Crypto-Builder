using System;

namespace CryptoBuilder.Crypto.Tls
{
    public abstract class CertificateStatusType
    {
        /*
         *  RFC 3546 3.6
         */
        public const byte ocsp = 1;
    }
}
