using SMPHCracker.Model.Enums;
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

        public string Bezeichnung { get { return bezeichnung; } set { bezeichnung = value; } }
        public Status Status { get { return status; } set { status = value; } }

    }
}
