using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    class Smartphone
    {
        private string bezeichnung;
        private Status status;
        //TODO
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public Status Status { get => status; set => status = value; }
    }
}
