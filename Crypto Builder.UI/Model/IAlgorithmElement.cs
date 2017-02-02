using CryptoBuilder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CryptoBuilder.Crypto;
using System.ComponentModel;

namespace CryptoBuilder.UI.Model
{
    public interface IAlgorithmElement
    {
        double X { get; set; }

        double Y { get; set; }

        string AlgorithmName { get; }

        byte[] Result { get; set; }

        byte[] Compute();
    }
}
