using SMPHCracker.Logic;
using SMPHCracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMPHCracker
{
    static class ThreadController
    {
        private static volatile bool _statusUpdateStop;
        private static Thread executeCommandThread;
        

        public static void StatusUpdateStart()
        {
            Thread thread = new Thread(() =>
            {
                while (!_statusUpdateStop)
                {
                    ViewModelLocator.MainView.GetStatus();

                    Thread.Sleep(TimeSpan.FromSeconds(3));
                }
            });
            thread.Start();
        }

        public static void StatusUpdateStop()
        {
            _statusUpdateStop = true;
        }

        public static void ExecuteCommandThread(ThreadStart action)
        {
            ExecuteCommandThreadStop();

            executeCommandThread = new Thread(action);
            executeCommandThread.IsBackground = true;
            executeCommandThread.Start();
        }

        public static void ExecuteCommandThreadStop()
        {
            if (executeCommandThread != null && executeCommandThread.IsAlive)
                executeCommandThread.Abort();
        }

        public static void StopAllThreads()
        {
            StatusUpdateStop();
            ExecuteCommandThreadStop();
        }
    }
}
