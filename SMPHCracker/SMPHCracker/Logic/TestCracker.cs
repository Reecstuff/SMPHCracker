using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    class TestCracker : ICracker
    {
        //TODO Auswahl an returns
        private Status status = Status.ADB;
        private string bezeichnung = "TestSmartphone";
        private int index = 0;

        public Status GetStatus()
        {
            //TODO Eingabe oder Random
            ////Umwandlung in Integer für spätere Eingabe
            //Random rnd = new Random();

            //int index = rnd.Next(0, 5);
            //return (Status)Enum.ToObject(typeof(Status), index);

            return this.status;
        }

        public void IncreaseStatus(bool bsp)
        {
            if (bsp)
            {
                if (status < Status.Sideload)
                    this.status++;
                else
                    status = Status.NoDevice;
            }
            else
            {
                if (status > Status.NoDevice)
                    this.status--;
                else
                    status = Status.Sideload;
            }
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
