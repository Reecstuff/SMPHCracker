using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    public interface ICracker
    {
        Status GetStatus();

        string Execute(ADBCommands command, params string[] str);

        string GetBezeichnung();

        //ShellSu
        bool RemovePassoword(Status status);

        bool EnableADB(Status status);

        bool VerifyADB(Status status);

        string ShowWLANKeys(Status status);
    }
}
