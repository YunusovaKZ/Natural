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
using System.Text.RegularExpressions;

namespace Natural
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        NaturelEntities _naturel = new NaturelEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Regex checkSpace = new Regex(@"\s", RegexOptions.None);
            Regex checkEmail = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.None);
            Regex checkPassword = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^]).*[A-Za-z\d!@#$%^]{6,}", RegexOptions.None);

            if ((tbE_mail.Text != string.Empty) &&
                  (passBox.Password == rePassBox.Password) &&
                  (!checkSpace.IsMatch(tbE_mail.Text) &&
                  (checkEmail.IsMatch(tbE_mail.Text) &&
                  (!checkSpace.IsMatch(passBox.Password) &&
                  checkPassword.IsMatch(passBox.Password)))))
            {
                if (_naturel.Users.Where(u => u.E_mail == tbE_mail.Text).FirstOrDefault() == null)
                {
                    Users user = new Users();
                    user.E_mail = tbE_mail.Text;
                    user.Password = passBox.Password;
                    user.Role = "Пользователь";
                    _naturel.Users.Add(user);
                    _naturel.SaveChanges();

                    MessageBox.Show("Регистрация прошла успешно!");
                    tbE_mail.Text = string.Empty;
                    passBox.Password = string.Empty;
                    rePassBox.Password = string.Empty;
                }
                else
                   MessageBox.Show("Данный логин уже занят.");
            }
            else
            {
                    MessageBox.Show(@"Ошибка!!
Необходимо задать логин.
Пароль  должен  отвечать  следующим требованиям: 
•  Минимум 6 символов 
•  Минимум 1 прописная буква 
•  Минимум 1 цифра 
•  Минимум один символ из набора: ! @ # $ % ^.");
                }
            }
            private void BtnAuto_Click(object sender, RoutedEventArgs e)
            {
             Autorization auto = new Autorization();
             auto.Show();
            }
        }
    }
