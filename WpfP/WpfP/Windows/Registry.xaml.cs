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
using System.Windows.Shapes;

namespace WpfP
{
    /// <summary>
    /// Логика взаимодействия для Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        public Registry()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (TBName.Text == "" || TBName.Text == null ||
                TBSurname.Text == "" || TBSurname.Text == null ||
                TBSecondName.Text == "" || TBSecondName.Text == null ||
                TBBirthday.Text == "" || TBBirthday.Text == null)
            {
                MessageBox.Show("Введите все значения");
            }
            else
            {
                try 
                {
                    User user = new User
                    {
                        Name = TBName.Text,
                        Surname = TBSurname.Text,
                        SecondName = TBSecondName.Text,
                        Birthday = Convert.ToUInt16(TBBirthday.Text)
                    };

                    DialogResult = true;
                    Tag = user;
                }
                catch
                {
                    MessageBox.Show("Некорректные значения");
                }
            }

        }
    }
}
