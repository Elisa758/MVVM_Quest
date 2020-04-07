using MVVM_Quest.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Quest
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MVVM_Quest.MainWindow window = new MainWindow();
            ShopViewModel VM = new ShopViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }
}
