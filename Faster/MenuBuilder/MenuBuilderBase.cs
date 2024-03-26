using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster.MenuBuilder
{
    public abstract class MenuBuilderBase
    {
        private Size menuItemSize = new Size(200, 35);

        public ToolStripItem[] MenuItems { get; set; }

        public MenuBuilderBase()
        {
            MenuItems = CreateMenu();
        }

        protected ToolStripMenuItem CreateToolStripMenuItem(string text, bool enable = true, Image image = null, bool bold=false, Size? size = null)
        {
            ToolStripMenuItem item = new ToolStripMenuItem
            {
                Text = text,
                AutoSize = false,
                Size = menuItemSize,
                Enabled = enable,
                Image = image
            };

            if (bold)
            {
                item.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold);
            }
            else
            {
                item.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular);
            }

            if (size != null)
            {
                item.Size = (Size)size;
            }

            return item;
        }

        protected abstract ToolStripItem[] CreateMenu();
    }
}
