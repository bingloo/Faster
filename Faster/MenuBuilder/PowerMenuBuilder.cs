using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster.MenuBuilder
{
    public class PowerMenuBuilder : MenuBuilderBase
    {
        protected override ToolStripItem[] CreateMenu()
        {

            ToolStripMenuItem item1 = CreateToolStripMenuItem("默认", image:Properties.Resources.Menu_Select);

            ToolStripMenuItem item2 = CreateToolStripMenuItem("允许息屏");

            ToolStripMenuItem item3 = CreateToolStripMenuItem("保持亮屏");

            SetMenuClick(item1, item2, item3);

            return new ToolStripItem[] { item1, item2, item3};
        }

        private void SetMenuClick(ToolStripMenuItem item_default, ToolStripMenuItem item_not_keep_display_on, ToolStripMenuItem item_keep_display_on)
        {
            item_default.Click += delegate
            {
                Library.PowerLib.RestoreSleep();
                item_default.Image = Properties.Resources.Menu_Select;
                item_keep_display_on.Image = null;
                item_not_keep_display_on.Image = null;
            };


            item_not_keep_display_on.Click += delegate
            {
                Library.PowerLib.SetNotSleep(false);
                item_default.Image = null;
                item_not_keep_display_on.Image = Properties.Resources.Menu_Select;
                item_keep_display_on.Image = null;

            };

            item_keep_display_on.Click += delegate
            {
                Library.PowerLib.SetNotSleep();
                item_default.Image = null;
                item_not_keep_display_on.Image = null;
                item_keep_display_on.Image = Properties.Resources.Menu_Select;
            };

        }
    }
}
