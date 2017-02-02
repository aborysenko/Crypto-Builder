﻿using System;

namespace CryptoBuilder.Crypto.Tls
{
    public abstract class AbstractTlsCredentials
        :   TlsCredentials
    {
        public abstract Certificate Certificate { get; }
    }
}
