using System;
using System.IO;

namespace CryptoBuilder.Crypto.Tls
{
    interface DtlsHandshakeRetransmit
    {
        /// <exception cref="IOException"/>
        void ReceivedHandshakeRecord(int epoch, byte[] buf, int off, int len);
    }
}
