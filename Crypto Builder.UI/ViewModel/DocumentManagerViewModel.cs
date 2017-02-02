using CryptoBuilder.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CryptoBuilder.UI.Helper;

namespace CryptoBuilder.UI.ViewModel
{
    public class DocumentManagerViewModel : BaseViewModel
    {
        private static int documents = 1;

        private DockWindowViewModel _activeDockWindow;

        public ObservableCollection<DockWindowViewModel> Documents { get; private set; } = new ObservableCollection<DockWindowViewModel>();

        public ObservableCollection<object> Anchorables { get; private set; } = new ObservableCollection<object>();

        public DockWindowViewModel ActiveDockWindow
        {
            get { return _activeDockWindow; }
            set
            {
                if (_activeDockWindow != value)
                {
                    _activeDockWindow = value;

                    OnPropertyChanged(nameof(ActiveDockWindow));
                }
            }
        }

        private ICommand _newProject;

        public ICommand NewProject
        {
            get
            {
                if (_newProject == null)
                    _newProject = new RelayCommand(action => CreateNewDocument());

                return _newProject;
            }
        }

        private ICommand _runProject;

        public ICommand RunProject
        {
            get
            {
                if (_runProject == null)
                    _runProject = new RelayCommand(action => RunProjectExecute(), canExecute => CanRunProjectExecute());
                return _runProject;
            }
        }

        public DocumentManagerViewModel(IEnumerable<DockWindowViewModel> dockWindowViewModels)
        {
            foreach (var document in dockWindowViewModels)
                CreateNewDocument(document);
        }

        private void DockWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DockWindowViewModel document = sender as DockWindowViewModel;

            if (e.PropertyName == nameof(DockWindowViewModel.IsClosed))
            {
                if (!document.IsClosed)
                    this.Documents.Add(document);
                else
                {
                    this.Documents.Remove(document);

                    if (Documents.Count == 0)
                        ActiveDockWindow = null;
                }
            }
        }

        public void CreateNewDocument()
        {
            DockWindowViewModel dockWindowViewModel = new ProjectDocumentViewModel() { Title = "Документ " + documents++ };

            CreateNewDocument(dockWindowViewModel);
        }

        private void CreateNewDocument(DockWindowViewModel dockWindowViewModel)
        {
            dockWindowViewModel.PropertyChanged += DockWindowViewModel_PropertyChanged;

            if (!dockWindowViewModel.IsClosed)
                this.Documents.Add(dockWindowViewModel);
        }

        public void RunProjectExecute()
        {
            if (ActiveDockWindow != null)
            {
                ProjectDocumentViewModel project = ActiveDockWindow as ProjectDocumentViewModel;

                foreach (var item in project.Algorithms)
                    item.Compute();
            }

        }

        public bool CanRunProjectExecute()
        {
            if (ActiveDockWindow != null)
            {
                ProjectDocumentViewModel project = ActiveDockWindow as ProjectDocumentViewModel;

                return project.Algorithms.Count != 0;
            }

            return false;
        }
    }
}
