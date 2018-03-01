using SMPHCracker.Logic;
using SMPHCracker.Model;
using SMPHCracker.ViewModel.Helper;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Input;

namespace SMPHCracker.ViewModel
{
    public class MainViewModel : NotifyPropertyChanged
    {
        #region Variables
        public SmartphoneViewModel Smartphone { get; set; } = new SmartphoneViewModel();

        //Switch to TestCracker if possible
        private ICracker cracker = new TestCracker();

        private string commandInput;
        private string log;

        public string CommandInput
        {
            get { return this.commandInput; }
            set
            {
                if(this.commandInput != value)
                {
                    this.commandInput = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Log
        {
            get { return this.log; }
            set
            {
                if (this.log != value)
                {
                    this.log = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Commands
        public ICommand RemovePasswordCommand { get; private set; }
        public ICommand EnableADBCommand { get; private set; }
        public ICommand VerifyADBCommand { get; private set; }
        public ICommand ExecuteCommand { get; private set; }
        public ICommand ShowWLANKeysCommand { get; private set; }

        public ICommand ArrowUpCommand { get; private set; }
        public ICommand ArrowDownCommand { get; private set; }

        #endregion

        public MainViewModel()
        {
            RemovePasswordCommand = new RelayCommand(RemovePassoword);
            EnableADBCommand = new RelayCommand(EnableADB);
            VerifyADBCommand = new RelayCommand(VerifyADB);
            ExecuteCommand = new RelayCommand(Execute);
            ShowWLANKeysCommand = new RelayCommand(ShowWLANKeys);

            ArrowUpCommand = new RelayCommand(IncreaseStatus);
            ArrowDownCommand = new RelayCommand(DecreaseStatus);

            Smartphone.PropertyChanged += Smartphone_PropertyChanged;

            ThreadController.StatusUpdateStart();
        }

        private void IncreaseStatus()
        {
            if (cracker is TestCracker)
            {
                (cracker as TestCracker).IncreaseStatus(true);
            }
        }

        private void DecreaseStatus()
        {
            if (cracker is TestCracker)
            {
                (cracker as TestCracker).IncreaseStatus(false);
            }
        }

        private void Smartphone_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "Status"))
                Smartphone.Bezeichnung = cracker.GetBezeichnung();
        }

        public void GetStatus()
        {
            this.Smartphone.Status = this.cracker.GetStatus();
        }

        //Shell-SU
        private void RemovePassoword()
        {
            bool action = cracker.RemovePassoword(this.Smartphone.Status);
        }

        //Recovery-Shell-Mode
        private void EnableADB()
        {
            bool action = cracker.EnableADB(this.Smartphone.Status);
        }

        //ADB-SU Mode
        private void VerifyADB()
        {
            bool action = cracker.VerifyADB(this.Smartphone.Status);
        }

        private void Execute()
        {
            Log = $"{Log}{Environment.NewLine}{ADB.Execute(ADBCommands.EXECUTE,CommandInput)}";
        }

        private void ShowWLANKeys()
        {
            Log = $"{Log}{Environment.NewLine}{cracker.ShowWLANKeys(this.Smartphone.Status)}";
        }
    }
}
