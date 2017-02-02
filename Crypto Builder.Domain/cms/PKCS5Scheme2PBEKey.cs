using System;

using CryptoBuilder.Asn1.Pkcs;
using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Generators;
using CryptoBuilder.Crypto.Parameters;

namespace CryptoBuilder.Cms
{
	/// <summary>
	/// PKCS5 scheme-2 - password converted to bytes assuming ASCII.
	/// </summary>
	public class Pkcs5Scheme2PbeKey
		: CmsPbeKey
	{
		[Obsolete("Use version taking 'char[]' instead")]
		public Pkcs5Scheme2PbeKey(
			string	password,
			byte[]	salt,
			int		iterationCount)
			: this(password.ToCharArray(), salt, iterationCount)
		{
		}

		[Obsolete("Use version taking 'char[]' instead")]
		public Pkcs5Scheme2PbeKey(
			string				password,
			AlgorithmIdentifier keyDerivationAlgorithm)
			: this(password.ToCharArray(), keyDerivationAlgorithm)
		{
		}
		
		public Pkcs5Scheme2PbeKey(
			char[]	password,
			byte[]	salt,
			int		iterationCount)
			: base(password, salt, iterationCount)
		{
		}

		public Pkcs5Scheme2PbeKey(
			char[]				password,
			AlgorithmIdentifier keyDerivationAlgorithm)
			: base(password, keyDerivationAlgorithm)
		{
		}

		internal override KeyParameter GetEncoded(
			string algorithmOid)
		{
			Pkcs5S2ParametersGenerator gen = new Pkcs5S2ParametersGenerator();

			gen.Init(
				PbeParametersGenerator.Pkcs5PasswordToBytes(password),
				salt,
				iterationCount);

			return (KeyParameter) gen.GenerateDerivedParameters(
				algorithmOid,
				CmsEnvelopedHelper.Instance.GetKeySize(algorithmOid));
		}
	}
}
