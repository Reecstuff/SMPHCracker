using SMPHCracker.Logic;
using SMPHCracker.Model;
using SMPHCracker.ViewModel.Helper;

namespace SMPHCracker.ViewModel.ModelsViewModel
{
    public class SmartphoneViewModel : NotifyPropertyChanged
    {
        private Smartphone smartphone = new Smartphone();
        private StatusViewModel status = new StatusViewModel();

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
        public StatusViewModel Status
        {
            get { return this.status; }
        }
    }
}
