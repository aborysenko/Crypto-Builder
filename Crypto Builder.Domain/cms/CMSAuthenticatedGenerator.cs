using System;
using System.IO;

using CryptoBuilder.Asn1;
using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Parameters;
using CryptoBuilder.Security;
using CryptoBuilder.Utilities.Date;
using CryptoBuilder.Utilities.IO;

namespace CryptoBuilder.Cms
{
	public class CmsAuthenticatedGenerator
		: CmsEnvelopedGenerator
	{
		/**
		* base constructor
		*/
		public CmsAuthenticatedGenerator()
		{
		}

		/**
		* constructor allowing specific source of randomness
		*
		* @param rand instance of SecureRandom to use
		*/
		public CmsAuthenticatedGenerator(
			SecureRandom rand)
			: base(rand)
		{
		}
	}
}
