using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using CryptoBuilder.Crypto;
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.View
{
    /// <summary>
    /// Логика взаимодействия для DigestControl.xaml
    /// </summary>
    public partial class DigestControl : UserControl, IAlgorithmElement, INotifyPropertyChanged
    {
        private IDigest _digest;

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
            get { return _digest.AlgorithmName; }
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

        public DigestControl(IDigest digest)
        {
            InitializeComponent();

            Y = X = 0;

            _digest = digest;

            DataContext = (IAlgorithmElement)this;
        }

        public byte[] Compute()
        {
            byte[] input = Encoding.ASCII.GetBytes(txtInput.Text);

            _digest.Reset();

            _digest.BlockUpdate(input, 0, input.Length);

            byte[] result = new byte[_digest.GetDigestSize()];

            _digest.DoFinal(result, 0);

            return (Result = result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
