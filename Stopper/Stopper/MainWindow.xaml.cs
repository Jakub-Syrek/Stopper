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
using System.Diagnostics;
using System.Windows.Threading;

namespace Stopper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Started = false;
        public Stopwatch stopWatch = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimePeriod(0, 0, 1);
            dispatcherTimer.Start();
           
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Started == false)
            {
                Zegar.Text = "0:0:0";
            }
            else
            {
                TimePeriod tp1 = new TimePeriod
                    (
                    Convert.ToInt64(stopWatch.Elapsed.Hours),
                    Convert.ToInt64(stopWatch.Elapsed.Minutes),
                    Convert.ToInt64(stopWatch.Elapsed.Seconds)
                    );
                Zegar.Text = tp1.ToString();
            }
        }
        private void StartStopper_Click(object sender, RoutedEventArgs e)
        {
            if (Started == false)
            {
                Started = true;
                stopWatch.Restart();
                StartStopper.Content = "Stop and reset stopper";
            }
            else
            {
                Started = false;
                StartStopper.Content = "Start stopper";
            }            
        }        
    }
}
