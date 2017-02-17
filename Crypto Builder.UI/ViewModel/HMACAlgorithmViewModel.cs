using CryptoBuilder.UI.Model;
using CryptoBuilder.Crypto;
using CryptoBuilder.crypto.macs;
using CryptoBuilder.UI.View;

namespace CryptoBuilder.UI.ViewModel
{
    public class HMACAlgorithmViewModel : AlgorithmViewModel
    {
        public HMACAlgorithmViewModel(string name) 
            : base(name)
        {
        }

        public override IAlgorithmElement CreateAlgorithmElement()
        {
            IMac hmac = HMACFactory.CreateDigets(Name);

            switch (hmac.AlgorithmName)
            {
                default:
                    return new HMACControl(hmac);
            }
        }
    }
}
