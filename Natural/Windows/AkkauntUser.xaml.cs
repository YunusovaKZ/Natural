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

namespace Natural
{
    /// <summary>
    /// Логика взаимодействия для AkkauntUser.xaml
    /// </summary>
    public partial class AkkauntUser : Window
    {
        private NaturelEntities _naturel = new NaturelEntities();
        public AkkauntUser()
        {
            InitializeComponent();

        }
        private void TbExit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Autorization auto = new Autorization();
            auto.Show();
        }

        private void BtnSaveBuyer_Click(object sender, RoutedEventArgs e)
        {
            _naturel.Buyer.Add(new Buyer()
            {
                Surname = TxtSurname.Text,
                Name = TxtName.Text,
                Otchestvo = TxtOtchestvo.Text,
                Birthday = DpBirthday.DisplayDate,
                Pasport = (int)Convert.ToInt64(TxtPasrort.Text),
                INN = (int)Convert.ToInt64(TxtINN.Text),
                Adress = TxtAdress.Text,
                Phone = (int)Convert.ToInt64(TxtPhone.Text),
                E_mail = TxtEmail.Text
            });
            _naturel.SaveChanges();

            this.Close();
        }


        /* _buyer.Surname= TxtSurname.Text;
         _buyer.Name = TxtName.Text;
         _buyer.Otchestvo = TxtOtchestvo.Text;
         _buyer.Birthday = DpBirthday.DisplayDate;
         _buyer.Pasport = Convert.ToInt32(TxtPasrort.Text);
         _buyer.INN = Convert.ToInt32(TxtINN.Text);
         _buyer.Adress = TxtAdress.Text;
         _buyer.Phone = Convert.ToInt32(TxtPhone.Text);
         _buyer.E_mail = TxtEmail.Text;
         _naturel.SaveChanges();
         this.Close();*/
    }
}
