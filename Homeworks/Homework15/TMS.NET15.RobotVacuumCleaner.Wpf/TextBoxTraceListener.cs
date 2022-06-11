using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TMS.NET15.RobotVacuumCleaner.Wpf
{
    internal class TextBoxTraceListener : TraceListener
    {
        private Dispatcher _dispatcher;
        private TextBox _txtOutput;

        public TextBoxTraceListener(TextBox txtConsole)
        {
            _dispatcher = Dispatcher.CurrentDispatcher;
            _txtOutput = txtConsole;
        }

        public override void Write(string message)
        {
            _dispatcher.BeginInvoke(() =>
            {
                _txtOutput.AppendText(string.Format("[{0}] ", DateTime.Now.ToString()));
                _txtOutput.AppendText(message);
            });
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
        }
    }
}
