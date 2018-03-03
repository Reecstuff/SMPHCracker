using SMPHCracker.Model.Enums;


namespace SMPHCracker.Logic
{
    public interface ICracker
    {
        StatusEnum GetStatus();

        string Execute(ADBCommands command, params string[] str);

        string GetBezeichnung();

        //ShellSu
        bool RemovePassoword(StatusEnum status);

        bool EnableADB(StatusEnum status);

        bool VerifyADB(StatusEnum status);

        string ShowWLANKeys(StatusEnum status);
    }
}
