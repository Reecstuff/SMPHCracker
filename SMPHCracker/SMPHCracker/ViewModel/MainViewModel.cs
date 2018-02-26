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

        #endregion

        public MainViewModel()
        {
            RemovePasswordCommand = new RelayCommand(RemovePassoword);
            EnableADBCommand = new RelayCommand(EnableADB);
            VerifyADBCommand = new RelayCommand(VerifyADB);
            ExecuteCommand = new RelayCommand(Execute);
            ShowWLANKeysCommand = new RelayCommand(ShowWLANKeys);

            Smartphone.Bezeichnung = cracker.GetBezeichnung();

            ThreadController.StatusUpdateStart();

            ADB.Start();
        }

        //ivate void CurrentDomain_ProcessExit(object sender, EventArgs e)
        //
        //  throw new NotImplementedException();
        //

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
            Log = $"{Log}{Environment.NewLine}{ADB.Execute(CommandInput)}";
        }

        private void ShowWLANKeys()
        {
            Log = $"{Log}{Environment.NewLine}{cracker.ShowWLANKeys(this.Smartphone.Status)}";
        }

        //private void RequestStop()
        //{
        //    _getStatusStop = true;
        //}
    }
}
