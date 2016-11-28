using CryptoBuilder.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoBuilder.UI.Helper;

namespace CryptoBuilder.UI.ViewModel
{
    public class AlgorithmTypeViewModel : BaseViewModel
    {
        private string _typeName;

        public string TypeName
        {
            get { return _typeName; }

            set
            {
                if (_typeName != value)
                {
                    OnPropertyChanging(nameof(TypeName));
                    _typeName = value;
                    OnPropertyChanged(nameof(TypeName));
                }
            }
        }

        private ObservableCollection<AlgorithmViewModel> _algoriths = new ObservableCollection<AlgorithmViewModel>();

        public ObservableCollection<AlgorithmViewModel> Algoriths
        {
            get { return _algoriths; }

            set
            {
                if (_algoriths != value)
                {
                    OnPropertyChanging(nameof(Algoriths));
                    _algoriths = value;
                    OnPropertyChanged(nameof(Algoriths));
                }
            }
        }

        public AlgorithmViewModel SelectedItem 
        {
            get { return _algoriths.FirstOrDefault(item => item.IsSelected); }
        }

        private ICommand _mouseDownCommand;

        public ICommand MouseDownCommand
        {
            get 
            {
                if (_mouseDownCommand == null)
                    _mouseDownCommand = new RelayCommand(call => DragDrop());

                return _mouseDownCommand;
            } 
        }

        private void DragDrop()
        {
            AlgorithmViewModel s = SelectedItem;
        }
    }
}
