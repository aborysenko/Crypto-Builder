using CryptoBuilder.Crypto;
using CryptoBuilder.Crypto.Parameters;
using CryptoBuilder.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoBuilder.UI.View
{
    /// <summary>
    /// Логика взаимодействия для HMACControl.xaml
    /// </summary>
    public partial class HMACControl : UserControl, IAlgorithmElement, INotifyPropertyChanged
    {
        private IMac _mac;

        private byte[] _result;

        private double _x;

        public double X
        {
            get { return _x; }

            set
            {
                if (_x != value)
                {
                    _x = value;

                    OnPropertyChanged(nameof(X));
                };
            }
        }

        private double _y;

        public double Y
        {
            get { return _y; }

            set
            {
                if (_y != value)
                {
                    _y = value;

                    OnPropertyChanged(nameof(Y));
                };
            }
        }

        public string AlgorithmName
        {
            get { return _mac.AlgorithmName; }
        }

        public byte[] Result
        {
            get { return _result; }

            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        private bool _isSelected;
       
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;

                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HMACControl(IMac mac)
        {
            InitializeComponent();

            Y = X = 0;

            _mac = mac;

            DataContext = (IAlgorithmElement)this;
        }

        public byte[] Compute()
        {
            byte[] key = Encoding.Default.GetBytes(txtKey.Text);

            byte[] input = Encoding.Default.GetBytes(txtInput.Text);

            _mac.Reset();

            _mac.Init(new KeyParameter(key));

            byte[] result = new byte[_mac.GetMacSize()];

            _mac.BlockUpdate(input, 0, input.Length);

            _mac.DoFinal(result, 0);

            return (Result = result);
        }
    }
}
