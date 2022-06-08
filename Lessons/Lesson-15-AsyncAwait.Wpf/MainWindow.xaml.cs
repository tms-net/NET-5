using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TMS.NET15.Lesson15.AsyncAwait.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // XAML
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // DispatcherSynchronizationContext

            // SynchronizationContext.SetSynchronizationContext(null);

            // IEnumerable -> GetEnumerator()

            txtOutput.Text = "LOADING...";

            // var result = await db.GetDataAsync()
            // txtOutput.Text = result;

            //var result = Task.Run(() => GetData()).Result;

            //var result = GetData().Result;

            var result = await Task.Run(() => GetData()).ConfigureAwait(true);

            //await GetAwaitable();

            //await Task.Yield();

            txtOutput.Text = result;
        }

        private async Task<string> GetData()
        {
            await Task.Yield();

            // запрос в БД
            var task = Task.Delay(5000);
            task = Task.WhenAny(task);

            var awaitable = task.ConfigureAwait(false);

            await awaitable;

            return "DATA";
        }

        private Awaitable GetAwaitable()
        {
            return new Awaitable();
        }
    }
}
