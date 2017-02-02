using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CryptoBuilder.UI.ViewModel;
using System.Collections.ObjectModel;

namespace CryptoBuilder.UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static  DocumentManagerViewModel DockManagerViewModel { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // документы
            var documents = new List<DockWindowViewModel>();

            DockManagerViewModel = new DocumentManagerViewModel(documents);

        }
    }
}
