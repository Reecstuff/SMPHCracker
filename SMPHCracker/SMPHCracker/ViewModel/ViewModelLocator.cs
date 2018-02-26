using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.ViewModel
{
    public static class ViewModelLocator
    {

        static MainViewModel MainViewModel;

        public static MainViewModel MainView
        {
            get
            {
                if (MainViewModel == null)
                {
                    MainViewModel = new MainViewModel();
                }

                return MainViewModel;
            }
        }
    }
}
