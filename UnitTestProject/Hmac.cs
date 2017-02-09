using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CryptoBuilder.Crypto.Macs;
using CryptoBuilder.Crypto.Digests;
using System.Text;
using CryptoBuilder.Crypto.Parameters;
using CryptoBuilder.Crypto;

namespace UnitTestProject
{
    [TestClass]
    public class HmacTest
    {
        private string RunHmac(IDigest digest)
        {
            string text = "12345";

            string key = "qwerty";

            var hmacMd5 = new HMac(digest);

            hmacMd5.Init(new KeyParameter(Encoding.Default.GetBytes(key)));

            byte[] result = new byte[hmacMd5.GetMacSize()];

            byte[] bytes = Encoding.Default.GetBytes(text);

            hmacMd5.BlockUpdate(bytes, 0, bytes.Length);

            hmacMd5.DoFinal(result, 0);

            return BitConverter.ToString(result).Replace("-", "").ToUpper();
        }

        [TestMethod]
        [TestCategory("Hmac")]
        public void TestHmacMD5()
        {
            //Arrange

            string expected = "e39ac2d096301fe4b8ac1411a9c4685b".ToUpper();

            //Act
            string outputHex = RunHmac(new MD5Digest());

            //Assert

            Assert.AreEqual(expected, outputHex);
        }

        [TestMethod]
        [TestCategory("Hmac")]
        public void TestHmacMD2()
        {
            //Arrange

            string expected = "dc6cebd4afcd4d877b3b3465bc416cc4".ToUpper();

            //Act
            string outputHex = RunHmac(new MD2Digest());

            //Assert

            Assert.AreEqual(expected, outputHex);
        }

        [TestMethod]
        [TestCategory("Hmac")]
        public void TestHmacMD4()
        {
            //Arrange

            string expected = "dd0ed0b1028221c6e2c1db1ad7acabfb".ToUpper();

            //Act
            string outputHex = RunHmac(new MD4Digest());

            //Assert

            Assert.AreEqual(expected, outputHex);
        }
    }
}
