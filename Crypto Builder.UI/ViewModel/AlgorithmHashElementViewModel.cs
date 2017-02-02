using CryptoBuilder.Domain;
using CryptoBuilder.UI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoBuilder.UI.ViewModel
{
    public  class AlgorithmHashElementViewModel : BaseViewModel
    {
        private ICommand _messageChanged;

        public ICommand MessageChanged
        {
            get
            {
                if (_messageChanged == null)
                    _messageChanged = new RelayCommand(m => InputMessage(m.ToString()));

                return _messageChanged;
            }
        }

        private byte[] _inputMessage;

        public byte[] Message
        {
            get { return _inputMessage; }

            set
            {
                if (_inputMessage != value)
                {
                    _inputMessage = value;

                   // Algorithm.ComputeData(_inputMessage);

                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        //public Algorithm Algorithm { get; private set; }

        //public AlgorithmHashElementViewModel(Algorithm algorithm)
        //{
        //    Algorithm = algorithm;
        //}

        private void InputMessage(string message)
        {
            Message = Helper.Helper.StringToByteArray(message);
        }

        private void KeyUpFunction(string msg)
        {
            int x = 9*9;
        }
    }
}
