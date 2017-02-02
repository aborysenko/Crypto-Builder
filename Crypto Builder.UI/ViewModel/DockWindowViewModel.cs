using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoBuilder.UI.Helper;
using CryptoBuilder.Domain;

namespace CryptoBuilder.UI.ViewModel
{
    public abstract class DockWindowViewModel : BaseViewModel
    {
        private ICommand _CloseCommand;

        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new RelayCommand(call => Close());
                return _CloseCommand;
            }
        }

        private bool _IsClosed;

        public bool IsClosed
        {
            get { return _IsClosed; }
            set
            {
                if (_IsClosed != value)
                {
                    OnPropertyChanging(nameof(IsClosed));
                    _IsClosed = value;
                    OnPropertyChanged(nameof(IsClosed));
                }
            }
        }

        private bool _CanClose;

        public bool CanClose
        {
            get { return _CanClose; }
            set
            {
                if (_CanClose != value)
                {
                    OnPropertyChanging(nameof(CanClose));
                    _CanClose = value;
                    OnPropertyChanged(nameof(CanClose));
                }
            }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    OnPropertyChanging(nameof(Title));
                    _Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public DockWindowViewModel()
        {
            this.CanClose = true;

            this.IsClosed = false;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

    }
}
