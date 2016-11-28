using System;
using System.Collections;
using System.IO;
using System.Text;

using CryptoBuilder.Asn1;
using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Crypto.Agreement;
using CryptoBuilder.Crypto.Agreement.Srp;
using CryptoBuilder.Crypto.Digests;
using CryptoBuilder.Crypto.Encodings;
using CryptoBuilder.Crypto.Engines;
using CryptoBuilder.Crypto.Generators;
using CryptoBuilder.Crypto.IO;
using CryptoBuilder.Crypto.Parameters;
using CryptoBuilder.Crypto.Prng;
using CryptoBuilder.Math;
using CryptoBuilder.Security;
using CryptoBuilder.Utilities;
using CryptoBuilder.Utilities.Date;

namespace CryptoBuilder.Crypto.Tls
{
    [Obsolete("Use 'TlsClientProtocol' instead")]
    public class TlsProtocolHandler
        :   TlsClientProtocol
    {
        public TlsProtocolHandler(Stream stream, SecureRandom secureRandom)
            :   base(stream, stream, secureRandom)
        {
        }

        /// <remarks>Both streams can be the same object</remarks>
        public TlsProtocolHandler(Stream input, Stream output, SecureRandom	secureRandom)
            :   base(input, output, secureRandom)
        {
        }
    }
}
