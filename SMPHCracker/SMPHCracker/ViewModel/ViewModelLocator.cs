using SMPHCracker.ViewModel.ViewsViewModel;

namespace SMPHCracker.ViewModel
{
    public sealed class ViewModelLocator
    {
        private static readonly MainViewModel mainView = new MainViewModel();

        public static MainViewModel MainView
        {
            get
            {
                return mainView;
            }
        }
    }
}
