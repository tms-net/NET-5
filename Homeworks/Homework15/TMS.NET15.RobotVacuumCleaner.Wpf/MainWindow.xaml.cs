using System.Diagnostics;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace TMS.NET15.RobotVacuumCleaner.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Trace.Listeners.Add(new TextBoxTraceListener(txtConsole));
        }

        public ControlBusCommand RobotCommand { get; private set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RobotCommand = new ControlBusCommand(new ControlBus());
            DataContext = this;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

            Trace.WriteLine("Запускаюсь...");

            // TODO: Запустить робот пылесос

            ((ToggleButton)sender).Content = "Выключить";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Выключаюсь...");

            // TODO: Завершить роботу робота пылесоса

            ((ToggleButton)sender).Content = "Включить";
        }
    }
}
