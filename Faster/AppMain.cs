using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Faster
{
    public class AppMain
    {

        private NotifyIcon myNotify = null;
        private void CreateTray()
        {
            myNotify = new NotifyIcon();
            myNotify.Icon = Properties.Resources.my_ico;
            myNotify.Text = "Faster";
            myNotify.ContextMenuStrip = CreateTrayMenu();

            myNotify.Visible = true;
            
        }

        private ContextMenuStrip CreateTrayMenu()
        {
            FlyUI.MaterialControls.Material_ContextMenuStrip menuStrip = new FlyUI.MaterialControls.Material_ContextMenuStrip();

            //ContextMenuStrip menuStrip = new ContextMenuStrip();
           
            ToolStripSeparator ts1 = new ToolStripSeparator();
            ToolStripSeparator ts2 = new ToolStripSeparator();

            menuStrip.Items.AddRange(new MenuBuilder.TopMenuBuilder().MenuItems);
            menuStrip.Items.Add(ts1);
            menuStrip.Items.AddRange(new MenuBuilder.PowerMenuBuilder().MenuItems);
            menuStrip.Items.Add(ts2);
            menuStrip.Items.AddRange(new MenuBuilder.BottomMenuBuilder().MenuItems);

            return menuStrip;
        }

        private void SetCapsLockMonitor()
        {
            Module.CapsLockMonitor clm = new Module.CapsLockMonitor();
            clm.OnCapsLockEvent += Clm_OnCapsLockEvent;
            bool success = clm.Run();
            if (!success)
            {
                clm.OnCapsLockEvent -= Clm_OnCapsLockEvent;
                SetNotifyIcon(Properties.Resources.my_ico);

                MessageBox.Show("CAPSLOCK MONITOR ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
            }
        }

        private void Clm_OnCapsLockEvent(bool isOn)
        {
            try
            {
                if (isOn)
                {
                    System.Diagnostics.Debug.WriteLine("CapsLock: On");
                    SetNotifyIcon(Properties.Resources.c_green_ico);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("CapsLock: Off");
                    SetNotifyIcon(Properties.Resources.c_yellow_ico);
                }
            }
            catch (Exception)
            { }
        }

        private object obj_lock = new object();
        private void SetNotifyIcon(Icon icon)
        {
            lock (obj_lock) 
            {
                myNotify.Icon = icon;
            }
        }

        public void Run()
        {
            CreateTray();

            SetCapsLockMonitor();

        }
    }
}
