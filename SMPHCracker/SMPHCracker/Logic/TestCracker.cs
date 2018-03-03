using SMPHCracker.Model;
using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    class TestCracker : ICracker
    {
        private Status status = Status.ADB;
        private string bezeichnung = "TestSmartphone";

        public Status GetStatus()
        {
            return this.status;
        }

        public void IncrementStatus()
        {
            if (status < Status.Sideload)
                this.status++;
            else
                status = Status.NoDevice;
        }

        public void DecrementStatus()
        {
            if (status > Status.NoDevice)
                this.status--;
            else
                status = Status.Sideload;
        }

        public string Execute(ADBCommands command, params string[] str)
        {
            return "Ausgeführt!";
        }

        public string GetBezeichnung()
        {
            return bezeichnung;
        }

        public bool RemovePassoword(Status status)
        {
            return true;
        }

        public bool EnableADB(Status status)
        {
            return true;
        }

        public bool VerifyADB(Status status)
        {
            return true;
        }

        public string ShowWLANKeys(Status status)
        {
            return "Keys";
        }
    }
}
