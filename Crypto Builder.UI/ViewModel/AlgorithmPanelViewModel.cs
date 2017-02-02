using CryptoBuilder.Domain;
using CryptoBuilder.UI.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoBuilder.Crypto.Digests;
using CryptoBuilder.UI.View;

namespace CryptoBuilder.UI.ViewModel
{
    public class AlgorithmPanelViewModel : BaseViewModel
    {
        private string _search = string.Empty;

        public string Search
        {
            get { return _search; }

            set
            {
                if (_search != value)
                {
                    OnPropertyChanging(nameof(Search));

                    _search = value;

                    SearchIcon = string.IsNullOrEmpty(_search) ? "Search" : "Close";

                    OnPropertyChanged(nameof(Search));

                    SearchAlgorithms();
                }
            }
        }

        private string _searchIcon;

        public string SearchIcon
        {
            get { return _searchIcon; }

            private set
            {
                if (_searchIcon != value)
                {
                    OnPropertyChanging(nameof(SearchIcon));
                    _searchIcon = value;
                    OnPropertyChanged(nameof(SearchIcon));
                }
            }
        }

        private ICommand _searchCommand;

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand((s) => ClearFilter());

                return _searchCommand;
            }
        }

        private ObservableCollection<AlgorithmTypeViewModel> _algorithmTypeViewModels = new ObservableCollection<AlgorithmTypeViewModel>();

        public ObservableCollection<AlgorithmTypeViewModel> AlgorithmTypeViewModels
        {
            get { return _algorithmTypeViewModels; }

            set
            {
                if (_algorithmTypeViewModels != value)
                {
                    OnPropertyChanging(nameof(AlgorithmTypeViewModels));
                    _algorithmTypeViewModels = value;
                    OnPropertyChanged(nameof(AlgorithmTypeViewModels));
                }
            }
        }

        public AlgorithmPanelViewModel()
        {
            SearchIcon = "Search";

            CreateDigest();
        }

        private void CreateDigest()
        {
            AlgorithmTypeViewModel AlgorithmTypeViewModel = new AlgorithmTypeViewModel() { TypeName = "Хэш функции" };

            foreach (var item in DigestFactory.Digests.Keys)
            {
                if (item.ToLower().Contains(Search.ToLower()))
                    AlgorithmTypeViewModel.Algoriths.Add(new DigestAlgorithmViewModel(item));
            }

            if(AlgorithmTypeViewModel.Algoriths.Count != 0)
                AlgorithmTypeViewModels.Add(AlgorithmTypeViewModel);
        }

        private void SearchAlgorithms()
        {
           AlgorithmTypeViewModels.Clear();

           CreateDigest();
        }

        private void ClearFilter()
        {
            Search = string.Empty;
        }
    }
}
