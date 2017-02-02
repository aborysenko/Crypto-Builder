using System;
using System.IO;

namespace CryptoBuilder.Crypto.Tls
{
    public interface TlsCipherFactory
    {
        /// <exception cref="IOException"></exception>
        TlsCipher CreateCipher(TlsContext context, int encryptionAlgorithm, int macAlgorithm);
    }
}
