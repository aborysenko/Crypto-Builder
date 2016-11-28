using System;
using System.IO;

namespace CryptoBuilder.Crypto.Tls
{
    public abstract class AbstractTlsAgreementCredentials
        :   AbstractTlsCredentials, TlsAgreementCredentials
    {
        /// <exception cref="IOException"></exception>
        public abstract byte[] GenerateAgreement(AsymmetricKeyParameter peerPublicKey);
    }
}
