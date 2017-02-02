using CryptoBuilder.UI.ViewModel;
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
using CryptoBuilder.UI.Model;

namespace CryptoBuilder.UI.View
{
    /// <summary>
    /// Логика взаимодействия для AlgorithmPanelControl.xaml
    /// </summary>
    public partial class AlgorithmPanelControl : UserControl
    {
        private AlgorithmPanelViewModel viewModel = new AlgorithmPanelViewModel();

        public AlgorithmPanelControl()
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock txtBlock = sender as TextBlock;

            AlgorithmViewModel algorithm = txtBlock.Tag as AlgorithmViewModel;

            var dragData = new DataObject(typeof(IAlgorithmElement), algorithm.CreateAlgorithmElement());

            DragDrop.DoDragDrop(txtBlock, dragData, DragDropEffects.Copy);
        }
    }
}
