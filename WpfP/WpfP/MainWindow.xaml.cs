using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Excel = Microsoft.Office.Interop.Excel;

namespace WpfP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
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
            Registry registry = new Registry()
            {
                Owner = this,
            };
            registry.ShowDialog();
            registry.Activate();
            if (registry.DialogResult != true)
            {
                Close();
                return;
            }

            Test = new Test1
            {
                Window = this,
                User1 = (User)registry.Tag
            };

            new Manual().ShowDialog();
        }

        public void UpdateProgress(int progress, Report report)
        {
            PBProgress.Value = progress;

            List<KeyValuePair<string, double>> valueList = new List<KeyValuePair<string, double>>
            {
                new KeyValuePair<string, double>("Общий\nтемп", report.GetTemp()),
                new KeyValuePair<string, double>("Эффективный\nтемп", report.GetSuccessTemp()),
                new KeyValuePair<string, double>("Общий\nтемп\n(левый)", report.GetLeftTemp()),
                new KeyValuePair<string, double>("Эффективный\nтемп\n(левый)", report.GetLeftSuccessTemp()),
                new KeyValuePair<string, double>("Общий\nтемп\n(правый)", report.GetRightTemp()),
                new KeyValuePair<string, double>("Эффективный\nтемп\n(правый)", report.GetRightSuccessTemp()),
                new KeyValuePair<string, double>("Время\nкоррекции", report.GetTimeCorrectSec()),
                new KeyValuePair<string, double>("Коэффициент\nреципрокности", report.GetRecip())
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
                player.Close();
            }
            Test.StartTest();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Report r = Test.GetReport();
            User u = Test.User1;

            if (r.IsEmpty() || u.IsEmpty())
            {
                System.Windows.MessageBox.Show("Нечего сохранять");
                return;
            }

            var sfd = new Microsoft.Win32.SaveFileDialog()
            { 
                AddExtension = true,
                DefaultExt = ".xlsx",
                ValidateNames = true,
                OverwritePrompt = false,
                Filter = "Excel files (*.xlsx)|*.xlsx"
            };
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    if (File.Exists(sfd.FileName))
                    {
                        Excel.Application exApp = new Excel.Application();
                        exApp.DisplayAlerts = false;
                        //exApp.Visible = true;
                        Workbook wb = exApp.Workbooks.Open(sfd.FileName);
                        Worksheet sh = wb.Worksheets[1];
                        //int lrow = sh.Cells[sh.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row; //последняя заполненная строка в столбце А
                        int lRow = sh.UsedRange.Rows.Count+1;
                        sh.Cells[lRow, 1] = u.Surname;
                        sh.Cells[lRow, 2] = u.Name;
                        sh.Cells[lRow, 3] = u.Group;
                        sh.Cells[lRow, 4] = u.Birthday;
                        sh.Cells[lRow, 5] = r.GetTemp();
                        sh.Cells[lRow, 6] = r.GetSuccessTemp();
                        sh.Cells[lRow, 7] = r.GetLeftTemp();
                        sh.Cells[lRow, 8] = r.GetLeftSuccessTemp();
                        sh.Cells[lRow, 9] = r.GetRightTemp();
                        sh.Cells[lRow, 10] = r.GetRightSuccessTemp();
                        sh.Cells[lRow, 11] = r.GetTimeCorrectSec();
                        sh.Cells[lRow, 12] = r.GetRecip();
                        wb.SaveAs(sfd.FileName);
                        //wb.Close(true);
                        exApp.Quit();
                    }
                    else
                    {
                        Excel.Application exApp = new Excel.Application();
                        exApp.DisplayAlerts = false;
                        //exApp.Visible = true;
                        Workbook wb = exApp.Workbooks.Add();
                        Worksheet sh = wb.ActiveSheet;

                        sh.Cells[1, 1] = "Фамилия";
                        sh.Cells[1, 2] = "Имя";
                        sh.Cells[1, 3] = "Группа";
                        sh.Cells[1, 4] = "Возраст";
                        sh.Cells[1, 5] = "Темп";
                        sh.Cells[1, 6] = "Эффективный темп";
                        sh.Cells[1, 7] = "Левый темп";
                        sh.Cells[1, 8] = "Эфф. левый темп";
                        sh.Cells[1, 9] = "Правый темп";
                        sh.Cells[1, 10] = "Эфф. правый темп";
                        sh.Cells[1, 11] = "Время коррекции";
                        sh.Cells[1, 12] = "Коэф. реципрокности";
                        sh.Cells[1, 13] = "Время";

                        sh.Cells[2, 1] = u.Surname;
                        sh.Cells[2, 2] = u.Name;
                        sh.Cells[2, 3] = u.Group;
                        sh.Cells[2, 4] = u.Birthday;
                        sh.Cells[2, 5] = r.GetTemp();
                        sh.Cells[2, 6] = r.GetSuccessTemp();
                        sh.Cells[2, 7] = r.GetLeftTemp();
                        sh.Cells[2, 8] = r.GetLeftSuccessTemp();
                        sh.Cells[2, 9] = r.GetRightTemp();
                        sh.Cells[2, 10] = r.GetRightSuccessTemp();
                        sh.Cells[2, 11] = r.GetTimeCorrectSec();
                        sh.Cells[2, 12] = r.GetRecip();
                        sh.Cells[2, 13] = DateTime.Now;
                        wb.SaveAs(sfd.FileName);
                        //wb.Close();
                        exApp.Quit();
                    }
                }
                catch(Exception ex) { System.Windows.MessageBox.Show(ex.Message); }
            }
        }
    }
}
