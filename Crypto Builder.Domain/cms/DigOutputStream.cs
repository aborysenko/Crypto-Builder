using System;

using CryptoBuilder.Crypto;
using CryptoBuilder.Utilities.IO;

namespace CryptoBuilder.Cms
{
	internal class DigOutputStream
		: BaseOutputStream
	{
		private readonly IDigest dig;

		internal DigOutputStream(IDigest dig)
		{
			this.dig = dig;
		}

		public override void WriteByte(byte b)
		{
			dig.Update(b);
		}

		public override void Write(byte[] b, int off, int len)
		{
			dig.BlockUpdate(b, off, len);
		}
	}
}
