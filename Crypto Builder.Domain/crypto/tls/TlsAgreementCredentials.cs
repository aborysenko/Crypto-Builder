using System;
using System.IO;

namespace CryptoBuilder.Crypto.Tls
{
    public interface TlsAgreementCredentials
        :   TlsCredentials
    {
        /// <exception cref="IOException"></exception>
        byte[] GenerateAgreement(AsymmetricKeyParameter peerPublicKey);
    }
}
