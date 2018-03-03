using SMPHCracker.Model.Enums;


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
