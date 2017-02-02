using System;
using System.IO;

namespace CryptoBuilder.Cms
{
	public interface CmsReadable
	{
		Stream GetInputStream();
	}
}
