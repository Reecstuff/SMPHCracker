using SMPHCracker.Model;
using SMPHCracker.Model.Enums;
using SMPHCracker.ViewModel.Helper;
using System.Runtime.CompilerServices;


namespace SMPHCracker.ViewModel.ModelsViewModel
{
    public class StatusViewModel : NotifyPropertyChanged
    {
        public Status status = new Status();
        private bool isStatusChanging;

        public StatusEnum EnumStatus
        {
            get { return status.EnumStatus; }
            set
            {
                if (EnumStatus != value)
                {
                    this.status.EnumStatus = value;
                    OnPropertyChanged();


                    switch (EnumStatus)
                    {
                        case StatusEnum.NoDevice:
                            IsNoDevice = true;
                            break;

                        case StatusEnum.Unauthorized:
                            IsUnauthorized = true;
                            break;

                        case StatusEnum.ADB:
                            IsAdb = true;
                            break;

                        case StatusEnum.Root:
                            IsRoot = true;
                            break;

                        case StatusEnum.Recovery:
                            IsRecovery = true;
                            break;

                        case StatusEnum.Sideload:
                            IsSideload = true;
                            break;
                    }
                }
            }
        }
        public bool IsNoDevice
        {
            get { return status.IsNoDevice; }
            set
            {
                if (IsNoDevice != value)
                {
                    status.IsNoDevice = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsUnauthorized
        {
            get { return status.IsUnauthorized; }
            set
            {
                if (IsUnauthorized != value)
                {
                    status.IsUnauthorized = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsAdb
        {
            get { return status.IsAdb; }
            set
            {
                if (IsAdb != value)
                {
                    status.IsAdb = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsRoot
        {
            get { return status.IsRoot; }
            set
            {
                if (IsRoot != value)
                {
                    status.IsRoot = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsRecovery
        {
            get { return status.IsRecovery; }
            set
            {
                if (IsRecovery != value)
                {
                    status.IsRecovery = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsSideload
        {
            get { return status.IsSideload; }
            set
            {
                if (IsSideload != value)
                {
                    status.IsSideload = value;
                    OnPropertyChanged();
                }

                StatusChanger();
            }
        }
        public bool IsRootXRecovery
        {
            get { return status.IsRootXRecovery; }
            private set
            {
                if (IsRootXRecovery != value)
                {
                    status.IsRootXRecovery = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRootXRecoveryXSideload
        {
            get { return status.IsRootXRecoveryXSideload; }
            private set
            {
                if (IsRootXRecoveryXSideload != value)
                {
                    status.IsRootXRecoveryXSideload = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRecoveryXSideload
        {
            get { return status.IsRecoveryXSideload; }
            private set
            {
                if (IsRecoveryXSideload != value)
                {
                    status.IsRecoveryXSideload = value;
                    OnPropertyChanged();
                }
            }
        }

        private void StatusChanger([CallerMemberName] string callerName = "")
        {
            if (!isStatusChanging)
            {
                isStatusChanging = true;

                switch (callerName)
                {
                    case "IsNoDevice":
                        if (IsNoDevice)
                        {
                            IsUnauthorized = false;
                            IsAdb = false;
                            IsRoot = false;
                            IsRecovery = false;
                            IsSideload = false;

                            IsRootXRecovery = false;
                            IsRootXRecoveryXSideload = false;
                            IsRecoveryXSideload = false;
                        }
                        break;

                    case "IsUnauthorized":
                        if (IsUnauthorized)
                        {
                            IsNoDevice = false;
                            IsAdb = false;
                            IsRoot = false;
                            IsRecovery = false;
                            IsSideload = false;

                            IsRootXRecovery = false;
                            IsRootXRecoveryXSideload = false;
                            IsRecoveryXSideload = false;
                        }
                        break;

                    case "IsAdb":
                        if (IsAdb)
                        {
                            IsNoDevice = false;
                            IsUnauthorized = false;
                            IsRoot = false;
                            IsRecovery = false;
                            IsSideload = false;

                            IsRootXRecovery = false;
                            IsRootXRecoveryXSideload = false;
                            IsRecoveryXSideload = false;
                        }
                        break;

                    case "IsRoot":
                        if (IsRoot)
                        {
                            IsNoDevice = false;
                            IsUnauthorized = false;
                            IsAdb = true;
                            IsRecovery = false;
                            IsSideload = false;

                            IsRootXRecovery = true;
                            IsRootXRecoveryXSideload = true;
                            IsRecoveryXSideload = false;
                        }
                        break;

                    case "IsRecovery":
                        if (IsRecovery)
                        {
                            IsNoDevice = false;
                            IsUnauthorized = false;
                            IsAdb = true;
                            IsRoot = true;
                            IsSideload = false;

                            IsRootXRecovery = true;
                            IsRootXRecoveryXSideload = true;
                            IsRecoveryXSideload = true;
                        }
                        break;

                    case "IsSideload":
                        if (IsSideload)
                        {
                            IsNoDevice = false;
                            IsUnauthorized = false;
                            IsAdb = false;
                            IsRoot = false;
                            IsRecovery = false;

                            IsRootXRecovery = false;
                            IsRootXRecoveryXSideload = true;
                            IsRecoveryXSideload = true;
                        }
                        break;

                    default:
                        IsNoDevice = true;
                        break;
                }

                isStatusChanging = false;
            }
        }
    }
}
