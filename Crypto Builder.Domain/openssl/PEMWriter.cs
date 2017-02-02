using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

using CryptoBuilder.Asn1;
using CryptoBuilder.Asn1.CryptoPro;
using CryptoBuilder.Asn1.Pkcs;
using CryptoBuilder.Asn1.X509;
using CryptoBuilder.Asn1.X9;
using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Generators;
using CryptoBuilder.Crypto.Parameters;
using CryptoBuilder.Math;
using CryptoBuilder.Pkcs;
using CryptoBuilder.Security;
using CryptoBuilder.Security.Certificates;
using CryptoBuilder.Utilities.Encoders;
using CryptoBuilder.Utilities.IO.Pem;
using CryptoBuilder.X509;

namespace CryptoBuilder.OpenSsl
{
	/// <remarks>General purpose writer for OpenSSL PEM objects.</remarks>
	public class PemWriter
		: CryptoBuilder.Utilities.IO.Pem.PemWriter
	{
		/// <param name="writer">The TextWriter object to write the output to.</param>
		public PemWriter(
			TextWriter writer)
			: base(writer)
		{
		}

		public void WriteObject(
			object obj) 
		{
			try
			{
				base.WriteObject(new MiscPemGenerator(obj));
			}
			catch (PemGenerationException e)
			{
				if (e.InnerException is IOException)
					throw (IOException)e.InnerException;

				throw e;
			}
		}

		public void WriteObject(
			object			obj,
			string			algorithm,
			char[]			password,
			SecureRandom	random)
		{
			base.WriteObject(new MiscPemGenerator(obj, algorithm, password, random));
		}
	}
}
