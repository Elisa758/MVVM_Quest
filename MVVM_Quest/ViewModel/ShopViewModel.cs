using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using MVVM_Quest.Model;

namespace MVVM_Quest.ViewModel
{

    class ShopViewModel
    {
        private IList<Shop> _ShopList;

        public ShopViewModel()
        {
            _ShopList = new List<Shop>
            {
                new Shop {ShopId=1,Name="Shop1",City="Strasbourg"},
                new Shop {ShopId=2,Name="Shop2",City="Metz"},
                new Shop {ShopId=3,Name="Shop3",City="Londres"}

            };
        }

        public IList<Shop> Shops
        {
            get
            {
                return _ShopList;
            }
            set
            {
                _ShopList = value;
            }
        }

        private ICommand mAdder;
        public ICommand AddCommand
        {
            get
            {
                if (mAdder == null)
                {
                    mAdder = new Adder();
                }
                return mAdder;
            }
            set
            {
                mAdder = value;
            }
        }

        private class Adder : ICommand
        {
            public object Shops { get; set; }


            #region ICommand Members 
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
            }

            #endregion
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
            }

            #endregion
        }
    }


}

