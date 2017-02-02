using System;

namespace CryptoBuilder.Cms
{
	internal interface IDigestCalculator
	{
		byte[] GetDigest();
	}
}
