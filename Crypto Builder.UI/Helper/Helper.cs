using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBuilder.UI.Helper
{
    public static class Helper
    {
        public static byte[] StringToByteArray(string hex)
        {
            string HEX = hex.Replace(" ", "").Replace("\r", "").Replace("\n", "");

            if (!string.IsNullOrEmpty(HEX) && HEX.Length % 2 != 0)
                HEX = HEX.Insert(HEX.Length - 1, "0");

            return Enumerable.Range(0, HEX.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(HEX.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
