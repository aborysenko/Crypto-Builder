using CryptoBuilder.UI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CryptoBuilder.UI.View;
using CryptoBuilder.Crypto.Digests;
using System.Windows.Input;
using CryptoBuilder.UI.Helper;
using System.Windows;

namespace CryptoBuilder.UI.ViewModel
{
    public class ProjectDocumentViewModel : DockWindowViewModel
    {
        private IAlgorithmElement _selectedElement;

        public IAlgorithmElement SelectedElement
        {
            get { return _selectedElement; }
            
            set 
            {
                if (_selectedElement != value)
                {
                    _selectedElement = value;

                    OnPropertyChanged(nameof(SelectedElement)); 
                }
            } 
        }

        public ObservableCollection<IAlgorithmElement> Algorithms { get; private set; } = new ObservableCollection<IAlgorithmElement>();

        private ICommand _algorithmDropCommand;

        public ICommand AlgorithmDropCommand
        {
            get
            {
                if (_algorithmDropCommand == null)
                    _algorithmDropCommand = new RelayCommand(AlgorithmDrop);

                return _algorithmDropCommand;
            }
        }

        private ICommand _deleteElementCommand;

        public ICommand DeleteElementCommand
        {
            get 
            {
                if (_deleteElementCommand == null)
                    _deleteElementCommand = new RelayCommand((c) => DeleteSelectedAlgorithmElement());

                return _deleteElementCommand;
            } 
        }

        public void DeleteSelectedAlgorithmElement()
        {
            while (SelectedElement != null)
                Algorithms.Remove(SelectedElement);
        }

        public void AlgorithmElement(IAlgorithmElement algorithm)
        {
            Algorithms.Add(algorithm);
        }

        private void AlgorithmDrop(object inObject)
        {
            DropData dropData = inObject as DropData;

            if (dropData == null) return;

            IAlgorithmElement algorithm = dropData.Data.GetData(typeof(IAlgorithmElement)) as IAlgorithmElement;

            if (algorithm == null) return;

            algorithm.X = dropData.Position.X;

            algorithm.Y = dropData.Position.Y;

            AlgorithmElement(algorithm);
        }
    }
}
