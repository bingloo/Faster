using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster.MenuBuilder
{
    public class TopMenuBuilder : MenuBuilderBase
    {
        protected override ToolStripItem[] CreateMenu()
        {
            ToolStripMenuItem item1 = CreateToolStripMenuItem("Faster", image: Properties.Resources.my_ico.ToBitmap(), bold:true);
            SetMenuClick(item1);
            return new ToolStripItem[] { item1 };
        }

        private void SetMenuClick(ToolStripMenuItem item)
        {
            item.Click += delegate
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "https://github.com/bingloo",
                    UseShellExecute = true
                };
                try
                {
                    Process.Start(psi);
                }
                catch(Exception)
                { }
            };
        }
    }
}
