using SMPHCracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMPHCracker
{
    static class ThreadController
    {
        private static volatile bool _statusUpdateStop;

        public static void StatusUpdateStart()
        {
            Thread thread = new Thread(StatusUpdateStartprivate);
            thread.Start();
        }

        private static void StatusUpdateStartprivate()
        {
            while (!_statusUpdateStop)
            {
                ViewModelLocator.MainView.GetStatus();

                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }
        public static void StatusUpdateStop()
        {
            _statusUpdateStop = true;
        }
    }
}
