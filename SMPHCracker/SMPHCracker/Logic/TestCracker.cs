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
        //private Status status = Status.ADB;
        private string bezeichnung = "TestSmartphone";

        public Status GetStatus()
        {
            //TODO Eingabe oder Random
            //Umwandlung in Integer für spätere Eingabe
            int index = (int)Status.ADB;
            return (Status)Enum.ToObject(typeof(Status), index);
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
