using CryptoBuilder.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.ViewModel
{
    public abstract class AlgorithmViewModel : BaseViewModel
    {
        public string Name {
            get; protected set;
        }

        private string _about;

        public string About 
        {
            get { return _about; }

            set
            {
                if (_about != value)
                {
                    OnPropertyChanging(nameof(About));
                    _about = value;
                    OnPropertyChanged(nameof(About));
                }
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                if (_isSelected != value)
                {
                    OnPropertyChanging(nameof(IsSelected));
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public AlgorithmViewModel(string name)
        {
            Name = name;   
        }

        public abstract IAlgorithmElement CreateAlgorithmElement();
    }
}
