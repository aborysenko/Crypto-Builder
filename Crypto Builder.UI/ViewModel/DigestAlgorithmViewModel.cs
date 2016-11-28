using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Digests;
using CryptoBuilder.UI.Model;
using CryptoBuilder.UI.View;
using CryptoBuilder.UI.View.Digest;

namespace CryptoBuilder.UI.ViewModel
{
    public class DigestAlgorithmViewModel : AlgorithmViewModel
    {
        public DigestAlgorithmViewModel(string name)
            :base(name)
        { }

        public override IAlgorithmElement CreateAlgorithmElement()
        {
            IDigest digest = DigestFactory.CreateDigets(Name);

            switch (digest.AlgorithmName)
            {
                case "Skein":
                    return new SkeinDigestControl(digest);
                default:
                    return new DigestControl(digest);
            }
        }
    }
}
