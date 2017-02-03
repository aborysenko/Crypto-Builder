using System;
using System.Collections.Generic;
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
using CryptoBuilder.UI.ViewModel;
using MahApps.Metro.Controls;

namespace CryptoBuilder.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public DocumentManagerViewModel ViewModel
        {
            get { return DataContext as DocumentManagerViewModel; }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = App.DockManagerViewModel;

            ViewModel.LayoutAnchorableAlgorithm = layoutAnchorableAlgorithm;

            ViewModel.LayoutAnchorableOutput = layoutAnchorableOutput;
        }
    }
}
