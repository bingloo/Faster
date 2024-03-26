using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faster.Library
{
    public class StartupLib
    {
        private readonly string startupKeyName = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";


        public void Add(string appName, string appValue)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(startupKeyName, true))
            {
                key?.SetValue(appName, appValue, RegistryValueKind.String); 
            }       
        }

        public void Delete(string appName) 
        {
            using (var key = Registry.CurrentUser.OpenSubKey(startupKeyName, true))
            {
                key?.DeleteValue(appName);
            }        
        }

        public bool Exists(string appName)
        {
            bool result = false;
            using (var key = Registry.CurrentUser.OpenSubKey(startupKeyName, true))
            {
                if (key != null && key.GetValue(appName)!=null)
                {
                    result = true;
                }
            }
            return result;
        }

        
    }
}
