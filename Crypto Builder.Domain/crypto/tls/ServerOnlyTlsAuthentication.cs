using System;

namespace CryptoBuilder.Crypto.Tls
{
    public abstract class ServerOnlyTlsAuthentication
        :   TlsAuthentication
    {
        public abstract void NotifyServerCertificate(Certificate serverCertificate);

        public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest)
        {
            return null;
        }
    }
}
