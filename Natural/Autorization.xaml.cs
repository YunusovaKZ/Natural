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
using System.Windows.Navigation;

namespace Natural
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        NaturelEntities _naturel = new NaturelEntities();
        public Autorization()
        {
            InitializeComponent();
            tbEmail.Focus();
        }


        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            var user = _naturel.Users.Where(u => u.E_mail == tbEmail.Text && u.Password == passBox.Password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
            else
            {
                switch (user.Role)
                {
                    case "Пользователь":
                        MainWindow main = new MainWindow();
                        main.Show();
                        break;
                    case "Менеджер":
                        MenedgerWorkUser MW = new MenedgerWorkUser();
                        MW.ShowDialog();
                        break;
                    case "Продавец":
                        Cosmetica cos = new Cosmetica();
                        cos.Show();
                        break;
                }
            }
        }
    }
}
