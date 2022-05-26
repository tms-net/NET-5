using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Lesson_11_TempTracker.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TempTracker _tempTracker;

        public MainWindow()
        {
            InitializeComponent();
            _tempTracker = new();
        }

        private void panelArea_MouseMove(object sender, MouseEventArgs e)
        {
            _tempTracker.Insert(this.PointToScreen(Mouse.GetPosition(this)).GetHashCode() / 100);

            txtMax.Text = _tempTracker.GetMax().ToString();
            txtMin.Text = _tempTracker.GetMin().ToString();
            txtMean.Text = _tempTracker.GetMean().ToString("#.#");
        }
    }
}
