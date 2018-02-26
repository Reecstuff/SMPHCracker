using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.ViewModel
{
    public sealed class ViewModelLocator
    {
        private static readonly MainViewModel mainView = new MainViewModel();

        public static MainViewModel MainView
        {
            get
            {
                return mainView;
            }
        }
    }
}
