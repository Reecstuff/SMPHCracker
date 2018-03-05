using SMPHCracker.Logic;
using SMPHCracker.Model.Enums;
using SMPHCracker.ViewModel.Helper;
using SMPHCracker.ViewModel.ModelsViewModel;
using System;
using System.Windows.Input;

namespace SMPHCracker.ViewModel.ViewsViewModel
{
    public class MainViewModel : NotifyPropertyChanged
    {
        #region Variables
        public SmartphoneViewModel Smartphone { get; set; } = new SmartphoneViewModel();

        //Switch to TestCracker if possible
        private ICracker cracker = new Cracker();

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

            new Zipper().MakeZip("lockscreenRemover");

            ThreadController.StatusUpdateStart();
        }

        private void Smartphone_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "Status"))
            {
                switch (Smartphone.Status)
                {
                    case Status.NoDevice:
                    case Status.Unauthorized:
                        Smartphone.Bezeichnung = string.Empty;
                        break;

                    case Status.ADB:
                    case Status.Root:
                    case Status.Recovery:
                    case Status.Sideload:
                        Smartphone.Bezeichnung = cracker.GetBezeichnung();
                        break;

                    default:
                        Smartphone.Bezeichnung = string.Empty;
                        break;
                }
            }
        }

        private void IncreaseStatus()
        {
            if (cracker is TestCracker)
            {
                (cracker as TestCracker).IncrementStatus();
            }
        }

        private void DecreaseStatus()
        {
            if (cracker is TestCracker)
            {
                (cracker as TestCracker).DecrementStatus();
            }
        }

        public void GetStatus()
        {
            Smartphone.Status = cracker.GetStatus();
        }

        private void RemovePassoword()
        {
            bool action = cracker.RemovePassoword(Smartphone.Status);
        }

        private void EnableADB()
        {
            bool action = cracker.EnableADB(Smartphone.Status);
        }

        private void VerifyADB()
        {
            bool action = cracker.VerifyADB(Smartphone.Status);
        }

        private void Execute()
        {
            //Prevents suspending because of incorrectly Shell-commands
            ThreadController.ExecuteCommandThread(() =>
            {
                Log = $"{Log}{Environment.NewLine}{cracker.Execute(ADBCommands.EXECUTE, CommandInput)}";
                CommandInput = String.Empty;
            });
        }

        private void ShowWLANKeys()
        {
            Log = $"{Log}{Environment.NewLine}{cracker.ShowWLANKeys(Smartphone.Status)}";
        }
    }
}
