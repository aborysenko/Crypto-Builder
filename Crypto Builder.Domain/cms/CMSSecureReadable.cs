using System;

using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Crypto.Parameters;

namespace CryptoBuilder.Cms
{
	internal interface CmsSecureReadable
	{
		AlgorithmIdentifier Algorithm { get; }
		object CryptoObject { get; }
		CmsReadable GetReadable(KeyParameter key);
	}
}
