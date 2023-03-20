using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace WpfP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Test1 Test;

        public MainWindow()
        {
            InitializeComponent();
        }


        public void Disable()
        {
            BtnNewUser.IsEnabled = false;
            BtnStart.IsEnabled = false;
            BtnSave.IsEnabled = false;
        }
        public void Enable()
        {
            BtnNewUser.IsEnabled = true;
            BtnStart.IsEnabled = true;
            BtnSave.IsEnabled = true;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BtnNewUser_Click(null, null);
        }

        private void BtnNewUser_Click(object sender, RoutedEventArgs e)
        {
            //Registry registry = new Registry()
            //{
            //    Owner = this,
            //};
            //registry.ShowDialog();
            //registry.Activate();
            //if (registry.DialogResult != true)
            //{
            //    Close();
            //    return;
            //}

            Test = new Test1
            {
                Window = this,
                //User1 = (User)registry.Tag
            };            
        }

        public void UpdateProgress(int progress, Report report)
        {
            PBProgress.Value = progress;

            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>
            {
                new KeyValuePair<string, int>("Developer", 60),
                new KeyValuePair<string, int>("Misc", 20),
                new KeyValuePair<string, int>("Tester", 50),
                new KeyValuePair<string, int>("QA", 30),
                new KeyValuePair<string, int>("Project Manager", 40)
            };
            DVCHistogram.DataContext = valueList;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + @"\Sound.mp3"))
            {
                MediaPlayer player = new MediaPlayer();
                player.Open(new Uri(Environment.CurrentDirectory + @"\Sound.mp3"));
                player.Play();
                while (player.Position != player.NaturalDuration) { }
            }
            Test.StartTest();

        }
    }
}
