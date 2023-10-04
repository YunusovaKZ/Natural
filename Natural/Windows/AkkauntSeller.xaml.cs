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
    /// Логика взаимодействия для AkkauntSeller.xaml
    /// </summary>
    public partial class AkkauntSeller : Window
    {
        private NaturelEntities _naturel = new NaturelEntities();
        public AkkauntSeller()
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
            _naturel.Seller.Add(new Seller()
            {
                Surname = TxtSurname.Text,
                Name = TxtName.Text,
                Otchestvo = TxtOtchestvo.Text,
                Birthday = DpBirthday.DisplayDate,
                Pasport = (int)Convert.ToInt64(TxtPasrort.Text),
                INN = (int)Convert.ToInt64(TxtINN.Text),
                Address = TxtAdress.Text,
                Phone = (int)Convert.ToInt64(TxtPhone.Text),
                Gender = TxtGender.Text,
                Salary = (int)Convert.ToInt64(TxtSelery.Text)
            });
            _naturel.SaveChanges();

            this.Close();
        }
    }
}
