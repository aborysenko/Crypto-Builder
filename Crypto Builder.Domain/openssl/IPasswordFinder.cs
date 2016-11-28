using System;

namespace CryptoBuilder.OpenSsl
{
	public interface IPasswordFinder
	{
		char[] GetPassword();
	}
}
