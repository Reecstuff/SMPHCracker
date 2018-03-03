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
        private StatusEnum status = StatusEnum.ADB;
        private string bezeichnung = "TestSmartphone";

        public StatusEnum GetStatus()
        {
            return this.status;
        }

        public void IncrementStatus()
        {
            if (status < StatusEnum.Sideload)
                this.status++;
            else
                status = StatusEnum.NoDevice;
        }

        public void DecrementStatus()
        {
            if (status > StatusEnum.NoDevice)
                this.status--;
            else
                status = StatusEnum.Sideload;
        }

        public string Execute(ADBCommands command, params string[] str)
        {
            return "Ausgeführt!";
        }

        public string GetBezeichnung()
        {
            return bezeichnung;
        }

        public bool RemovePassoword(StatusEnum status)
        {
            return true;
        }

        public bool EnableADB(StatusEnum status)
        {
            return true;
        }

        public bool VerifyADB(StatusEnum status)
        {
            return true;
        }

        public string ShowWLANKeys(StatusEnum status)
        {
            return "Keys";
        }
    }
}
