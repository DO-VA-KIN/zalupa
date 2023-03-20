using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using Timer = System.Threading.Timer;

namespace WpfP
{
    public struct User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public ushort Birthday { get; set; }
    }
    public struct Report
    {
        public ushort LeftSuccess;
        public ushort RightSuccess;
 
        public ushort LeftError;
        public ushort RightError;
    }

    public class Result
    {
        public string name = "21";
        public int value = 0;
    }



    public class Test1
    {
        public MainWindow Window { get; set; }
        public User User1 { get; set; }
        private Report Report1 = new Report();

        private System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public TimeSpan Time = new TimeSpan(0, 0, 30);

        private System.Windows.Threading.DispatcherTimer ReportTimer = new System.Windows.Threading.DispatcherTimer();
        private TimeSpan ReportInterval = new TimeSpan(0, 0, 1);
        private int Ticks = 0;

        private bool FlipFlop = true;

        public void StartTest()
        {
            Report1 = new Report();
            Ticks = 1;
            FlipFlop = false;

            //Window.Topmost = true;
            Window.Disable();
            ReportTimer.Interval = ReportInterval;
            Timer.Interval = Time;
            Window.KeyDown += Window_KeyDown;
            ReportTimer.Tick += ReportTimer_Tick;
            Timer.Tick += Timer_Tick;
            ReportTimer.Start();
            Timer.Start();
        }

        private void ReportTimer_Tick(object sender, EventArgs e)
        {
            Ticks++;
            int progress = (int)(ReportInterval.TotalSeconds * 100 * Ticks / Time.TotalSeconds);
            Window.UpdateProgress(progress, Report1);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Window.UpdateProgress(100, Report1);
            ReportTimer.Stop();
            ReportTimer.Tick -= ReportTimer_Tick;

            Timer.Stop();
            Window.KeyDown -= Window_KeyDown;
            Timer.Tick -= Timer_Tick;
            Window.Topmost = false;
            Window.Enable();
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (e.IsRepeat)
            {
                if (FlipFlop)
                    Report1.LeftError++;
                else Report1.RightError++;
                return;
            }

            if(e.Key == Key.LeftShift)
            {
                if (FlipFlop) Report1.LeftSuccess++;
                else Report1.LeftError++;
            }
            else if (e.Key == Key.RightShift)
            {
                if (!FlipFlop) Report1.RightSuccess++;
                else Report1.RightError++;
            }
            else
            {
                if (FlipFlop)
                    Report1.LeftError++;
                else Report1.RightError++;
            }

            FlipFlop = ! FlipFlop;
        }

    }
}
