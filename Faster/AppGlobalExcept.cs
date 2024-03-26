using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faster
{
    public class AppGlobalExcept
    {
        private class ExceptData
        {
            public string Type { get; set; } = string.Empty;

            public string Name { get; set; } = string.Empty;

            public string Message { get; set; } = string.Empty;

            public string StackTrace { get; set; } = string.Empty;
           
            public string Code { get; set; } = string.Empty;
        }

        public void Run()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (x, y) =>
            {
                SetException(y.Exception, "Application.ThreadException");
            };

            AppDomain.CurrentDomain.UnhandledException += (x, y) =>
            {
                Exception exception = y.ExceptionObject as Exception;
                if (exception != null)
                {
                    SetException(exception, "AppDomain.CurrentDomain.UnhandledException");
                }
            };
        }


        private void SetException(Exception exception, string exceptionType)
        {

            ExceptData data = new ExceptData();

            data.Type= exceptionType;

            if (exception.GetType() != null && exception.GetType().FullName != null)
            {
                string str = exception.GetType().FullName;
                if (str != null)
                {
                    data.Name = str;
                }
            }

            if (exception.Message != null)
            {
                data.Message = exception.Message;
            }
            if (exception.StackTrace != null)
            {
                data.StackTrace = exception.StackTrace;
            }

           
            HandleException(data);

        }

        private void HandleException(ExceptData data)
        {
            string str = $"[{DateTime.Now}]\n[{data.Type}]\n" +
                $"[Name] {data.Name}\n" +
                $"[Message] {data.Message}\n" +
                $"[StackTrace]\n{data.StackTrace}";
            MessageBox.Show(str, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

    }
}
