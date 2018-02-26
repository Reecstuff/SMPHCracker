using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel MainView
        {
            get { return new MainViewModel(); }
        }
    }
}
