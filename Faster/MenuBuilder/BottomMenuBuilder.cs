using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster.MenuBuilder
{
    public class BottomMenuBuilder : MenuBuilderBase
    {
        protected override ToolStripItem[] CreateMenu()
        {
            ToolStripMenuItem item1 = CreateToolStripMenuItem("开机启动");

            ToolStripMenuItem item2 = CreateToolStripMenuItem("关于");

            ToolStripMenuItem item3 = CreateToolStripMenuItem("退出");

            SetMenuClick(item1, item2, item3);

            return new ToolStripItem[] { item1, item2, item3};
        }
        private string GetVersion()
        {
            var data = (AssemblyFileVersionAttribute[])Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (data != null && data.Length > 0)
            {
                return data[0].Version.ToString();
            }
            return "NULL";
        }

        private void SetMenuClick(ToolStripMenuItem item_startup, ToolStripMenuItem item_about, ToolStripMenuItem item_exit)
        {
            item_about.Click += delegate
            {
                MessageBox.Show($"Email: avb@live.com\nGithub: https://github.com/bingloo\nVersion: {GetVersion()}", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    var info = new ProcessStartInfo("https://github.com/bingloo");
                    info.UseShellExecute = true;
                    Process.Start(info);
                }
                catch (Exception)
                { }

            };
            item_exit.Click += delegate
            {
                Application.Exit();
            };

            SetStartup(item_startup);
           
        }

        private void SetStartup(ToolStripMenuItem item_startup)
        {
            string appName = "Faster";

            string appValue = Application.ExecutablePath;

            Library.StartupLib sl = new Library.StartupLib();
            bool isStartup = sl.Exists(appName);
            if (isStartup)
            {
                item_startup.Image = Properties.Resources.Menu_Select;
            }
            else
            {
                item_startup.Image = null;
            }

            item_startup.Click += delegate
            {
                isStartup = sl.Exists(appName);
                if (isStartup)
                {
                    sl.Delete(appName);
                    item_startup.Image = null;
                }
                else
                {
                    sl.Add(appName, appValue);
                    item_startup.Image = Properties.Resources.Menu_Select;
                }
            };
        }
    }
}
