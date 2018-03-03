using SMPHCracker.Logic;
using SMPHCracker.Model;
using SMPHCracker.Model.Enums;
using SMPHCracker.ViewModel.Helper;

namespace SMPHCracker.ViewModel.ModelsViewModel
{
    public class SmartphoneViewModel : NotifyPropertyChanged
    {
        private Smartphone smartphone = new Smartphone();

        public string Bezeichnung
        {
            get { return this.smartphone.Bezeichnung; }
            set
            {
                if(Bezeichnung != value)
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
                if(Status != value)
                {
                    this.smartphone.Status = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
