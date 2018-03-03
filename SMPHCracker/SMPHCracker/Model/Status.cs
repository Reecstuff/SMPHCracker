using SMPHCracker.Model.Enums;

namespace SMPHCracker.Model
{
    public class Status
    {
        private StatusEnum enumStatus;

        private bool isNoDevice;
        private bool isUnauthorized;
        private bool isAdb;
        private bool isRoot;
        private bool isRecovery;
        private bool isSideload;
        private bool isRootXRecovery;
        private bool isRootXRecoveryXSideload;
        private bool isRecoveryXSideload;

        public StatusEnum EnumStatus { get { return enumStatus; } set { enumStatus = value; } }
        public bool IsNoDevice { get { return isNoDevice; } set { isNoDevice = value; } }
        public bool IsUnauthorized { get { return isUnauthorized; } set { isUnauthorized = value; } }
        public bool IsAdb { get { return isAdb; } set { isAdb = value; } }
        public bool IsRoot { get { return isRoot; } set { isRoot = value; } }
        public bool IsRecovery { get { return isRecovery; } set { isRecovery = value; } }
        public bool IsSideload { get { return isSideload; } set { isSideload = value; } }
        public bool IsRootXRecovery { get { return isRootXRecovery; } set { isRootXRecovery = value; } }
        public bool IsRootXRecoveryXSideload { get { return isRootXRecoveryXSideload; } set { isRootXRecoveryXSideload = value; } }
        public bool IsRecoveryXSideload { get { return isRecoveryXSideload; } set { isRecoveryXSideload = value; } }
    }
}
