using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 *  EMail: avb@live.com
 * Github: https://github.com/bingloo 
 */

namespace Faster.Library
{
    public class KeyHookLib
    {

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;

        private const int WM_KEYUP = 0x0101;

        private IntPtr hookId = IntPtr.Zero;

        private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void OnKeyDownHandler(int vkCode, out bool hookReturn);

        public event OnKeyDownHandler OnKeyDownEvent;

        public delegate void OnKeyUpHandler(int vkCode, out bool hookReturn);

        public event OnKeyUpHandler OnKeyUpEvent;

        private HookProc hProc = null;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        public struct HookStruct
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        
        /// <summary>
        /// 安装钩子
        /// </summary>
        /// <returns></returns>
        public bool InstallHook()
        {
            // 安装键盘钩子
            if (hookId != IntPtr.Zero)
            {
                UnInstallHook();
            }

            try
            {
                hProc = new HookProc(HookCallback);

                using (Process pc = Process.GetCurrentProcess())
                {
                    var pModule = pc.MainModule;
                    if (pModule != null && pModule.ModuleName != null)
                    {
                        IntPtr hMod = GetModuleHandle(pModule.ModuleName);
                        hookId = SetWindowsHookEx(WH_KEYBOARD_LL, hProc, hMod, 0);
                    }
                }
            }
            catch (Exception)
            { }

            //如果设置钩子失败.
            if (hookId == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }

        public bool UnInstallHook()
        {
            if (hookId == IntPtr.Zero)
            {
                return true;
            }

            bool ret = UnhookWindowsHookEx(hookId);
            if (ret)
            {
                hookId = IntPtr.Zero;
            }
            return ret;
        }

        [HandleProcessCorruptedStateExceptions]
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_KEYUP))
            {
                int vkCode = 0;

                // vkCode = Marshal.ReadInt32(lParam);
                var data = Marshal.PtrToStructure(lParam, typeof(HookStruct));
                if (data != null)
                {
                    HookStruct hs = (HookStruct)data;
                    vkCode = Convert.ToInt32(hs.vkCode);
                }

                //Debug.WriteLine($"vkCode: {vkCode}");

                bool hookReturn = false;

                if (wParam == (IntPtr)WM_KEYDOWN && OnKeyDownEvent != null && vkCode != 0)
                {
                    OnKeyDownEvent?.Invoke(vkCode, out hookReturn);
                    if (hookReturn)
                    {
                        return new IntPtr(1);
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP && OnKeyUpEvent != null && vkCode != 0)
                {
                    OnKeyUpEvent?.Invoke(vkCode, out hookReturn);
                    if (hookReturn)
                    {
                        return new IntPtr(1);
                    }
                }

            }

            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }
    }
}
