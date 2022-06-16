using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace TMS.NET15.RobotVacuumCleaner.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private VacuumCleaner _vacuumCleaner;
        private ControlBus _controlBus;
        private Thread _thread;

        public MainWindow()
        {
            InitializeComponent();
            Trace.Listeners.Add(new TextBoxTraceListener(txtConsole));
        }

        public ControlBusCommand RobotCommand { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _controlBus = new ControlBus();
            _controlBus.CommandExecuted += args =>
            {
                Dispatcher.Invoke(() => txtConsole.Text += $"\n{args.Command}");
            };
            RobotCommand = new ControlBusCommand(_controlBus);
            DataContext = this;

            Task.Run(() => Task.Delay(5000)
            .ContinueWith(t =>
            {
                _controlBus.SendCommand("ReturnToChargingDock");
            }));
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Запускаюсь...");

            _vacuumCleaner = new VacuumCleaner(_controlBus);
            _vacuumCleaner.Start();

            _thread = new Thread(_vacuumCleaner.Run);
            _thread.IsBackground = false;
            _thread.Start();

            ((ToggleButton)sender).Content = "Выключить";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Выключаюсь...");

            _vacuumCleaner.Stop();

            if (!_thread.Join(1000 * 10))
            {
                _thread.Interrupt();
            }

            ((ToggleButton)sender).Content = "Включить";
        }
    }
}
