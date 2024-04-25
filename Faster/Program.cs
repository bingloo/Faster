using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool createdNew;
            Mutex mt = new Mutex(true, "FASTER_APP", out createdNew);
            if (createdNew)
            {
                new AppExcept().Run();

                new AppMain().Run();

                Application.Run();

                mt.ReleaseMutex();
            }
        }
    }
}
