using SMPHCracker.Logic;
using SMPHCracker.Model;
using SMPHCracker.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.ViewModel
{
    public class SmartphoneViewModel : NotifyPropertyChanged
    {
        private Smartphone smartphone = new Smartphone();

        public string Bezeichnung
        {
            get { return this.smartphone.Bezeichnung; }
            set
            {
                if(this.smartphone.Bezeichnung != value)
                {
                    this.smartphone.Bezeichnung = value;
                    OnPropertyChanged();
                }
            }
        }

        public Status Status
        {
            get { return this.smartphone.Status; }
            set
            {
                if (this.smartphone.Status != value)
                {
                    this.smartphone.Status = value;
                    OnPropertyChanged();
                }

            }
        }
    }
}
