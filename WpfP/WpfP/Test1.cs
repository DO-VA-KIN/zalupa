using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Timer = System.Threading.Timer;

namespace WpfP
{
    public struct User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public ushort Birthday { get; set; }
        public bool IsEmpty()
        { return Name == null && Surname == null && Group == null; }
    }
    public struct Report
    {
        const double time = 30;
        public ushort LeftSuccess;
        public ushort RightSuccess;
        public ushort LeftError;
        public ushort RightError;
        public TimeSpan TimeCorrect;

        public double GetTemp()
        { 
            //if(LeftSuccess + LeftError + RightSuccess + RightError == 0)
            //    return 0;
            return time / (LeftSuccess + LeftError + RightSuccess + RightError);
        }
        public double GetSuccessTemp()
        {
            //if (LeftSuccess + RightSuccess == 0)
            //    return 0;
            return time / (LeftSuccess + RightSuccess);
        }
        public double GetLeftTemp()
        {
            //if (LeftSuccess + LeftError == 0)
            //    return 0;
            return time / (LeftSuccess + LeftError);
        }
        public double GetLeftSuccessTemp()
        {
            //if (LeftSuccess == 0)
            //    return 0;
            return time / (LeftSuccess);
        }
        public double GetRightTemp()
        {
            //if (RightSuccess + RightError == 0)
            //    return 0;
            return time / (RightSuccess + RightError);
        }
        public double GetRightSuccessTemp()
        {
            //if (RightSuccess == 0)
            //    return 0;
            return 30 / (RightSuccess);
        }
        public double GetRecip()
        {
            //if(GetLeftTemp() == 0)
            //    return 0;
            return GetRightTemp() / GetLeftTemp();
        }
        public double GetTimeCorrectSec()
        { return TimeCorrect.TotalMilliseconds / 1000; }

        public bool IsEmpty()
        { return LeftSuccess == 0 && RightSuccess == 0 && LeftError == 0 && RightError == 0; }
    }            



    public class Test1
    {
        public MainWindow Window { get; set; }
        public User User1 { get; set; }
        private Report Report1 = new Report();
        public Report GetReport()
        { return Report1; }

        private System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        public TimeSpan Time = new TimeSpan(0, 0, 30);

        private System.Windows.Threading.DispatcherTimer ReportTimer = new System.Windows.Threading.DispatcherTimer();
        private TimeSpan ReportInterval = new TimeSpan(0, 0, 3);
        private int Ticks = 0;

        private bool FlipFlop = true;
        private bool Error = false;
        private TimeSpan TimeError = new TimeSpan(0, 0, 0);

        public void StartTest()
        {
            Report1 = new Report()
            {
                LeftSuccess = 1,
                RightSuccess = 1,
                LeftError = 1,
                RightError = 1,
                TimeCorrect = new TimeSpan(0,0,0)
            };
            Ticks = 1;
            FlipFlop = false;

            if (File.Exists(Environment.CurrentDirectory + @"\Sound.mp3"))
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(Environment.CurrentDirectory + @"\Sound.mp3"));
                player.Play();
                while (player.Position != player.NaturalDuration) { }
                player.Close();
            }

            Window.Topmost = true;
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
            Ticks += 3;
            int progress = (int)(ReportInterval.TotalSeconds * 100 * Ticks / ReportInterval.TotalSeconds / Time.TotalSeconds);
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

            if (File.Exists(Environment.CurrentDirectory + @"\Sound.mp3"))
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(Environment.CurrentDirectory + @"\Sound.mp3"));
                player.Play();
                while (player.Position != player.NaturalDuration) { }
                player.Close();
            }
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
                if (FlipFlop)
                {
                    Report1.LeftSuccess++;
                    if (Error)
                        Report1.TimeCorrect = new TimeSpan(Report1.TimeCorrect.Add(DateTime.Now.TimeOfDay.Subtract(TimeError)).Ticks / 2);
                    Error = false;
                }
                else
                {
                    Report1.LeftError++;
                    TimeError = DateTime.Now.TimeOfDay;
                    Error = true;
                }
            }
            else if (e.Key == Key.RightShift)
            {
                if (!FlipFlop)
                {
                    Report1.RightSuccess++;
                    if (Error)
                        Report1.TimeCorrect = new TimeSpan(Report1.TimeCorrect.Add(DateTime.Now.TimeOfDay.Subtract(TimeError)).Ticks / 2);
                    Error = false;
                }
                else
                {
                    Report1.RightError++;
                    TimeError = DateTime.Now.TimeOfDay;
                    Error = true;
                }
            }
            else
            {
                if (FlipFlop) Report1.LeftError++;
                else Report1.RightError++;
            }

            if (!Error)
                FlipFlop = ! FlipFlop;
        }

    }
}
