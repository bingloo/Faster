using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster.Module
{
    public class CapsLockMonitor
    {

        public delegate void OnCapsLockHandler(bool isOn);

        public event OnCapsLockHandler OnCapsLockEvent;

        private Library.KeyHookLib keyHook = null;

        private const int VK_CAPITAL = 0x14;

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [HandleProcessCorruptedStateExceptions]
        private bool GetCapsLockState()
        {
            try
            {
                short state = GetKeyState(VK_CAPITAL);
                return (state & 0x0001) != 0;
            }
            catch (Exception)
            { }
            return false;
        }

        public bool Run()
        {
            keyHook = new Library.KeyHookLib();

            keyHook.OnKeyUpEvent += Kh_OnKeyUpEvent;

            bool isInstall = keyHook.InstallHook();
            System.Diagnostics.Debug.WriteLine($"Install Hook: {isInstall}");

            if (isInstall)
            {
                SetStatus();
            }

            Application.ApplicationExit += delegate
            {
                DisposeHook();
            };
            return isInstall;
        }

        public void DisposeHook()
        {
            bool bb = keyHook.UnInstallHook();
            System.Diagnostics.Debug.WriteLine($"UnInstall Hook: {bb}");
        }


        private void Kh_OnKeyUpEvent(int vkCode, out bool hookReturn)
        {
            hookReturn = false;
            if (vkCode == (int)Keys.CapsLock)
            {
                SetStatus();
            }
        }

        private void SetStatus()
        {
            //try
            //{
            //    if (Control.IsKeyLocked(Keys.CapsLock))
            //    {
            //        OnCapsLockEvent?.Invoke(true);
            //    }
            //    else
            //    {
            //        OnCapsLockEvent?.Invoke(false);
            //    }
            //}
            //catch (Exception)
            //{ }
            if (GetCapsLockState())
            {
                OnCapsLockEvent?.Invoke(true);
            }
            else
            {
                OnCapsLockEvent?.Invoke(false);
            }

        }
    }
}
