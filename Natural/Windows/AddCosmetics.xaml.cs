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

namespace Natural.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCosmetics.xaml
    /// </summary>
    public partial class AddCosmetics : Window
    {
        private NaturelEntities _naturel;
        private Cosmetica _window;
        public AddCosmetics(NaturelEntities naturelEntities, Cosmetica cosmetica)
        {
            InitializeComponent();
            this._naturel = naturelEntities;
            this._window = cosmetica;
        }

        private void BtnAddCosmetic_Click(object sender, RoutedEventArgs e)
        {
            if (TxtNameCosmetics.Text == "" || TxtNumber.Text == "" || TxtPrice.Text == "" || Manufacture.SelectedDate == null || Expiration.SelectedDate == null)
            {
                MessageBox.Show("Введите данные");
            }
            else
            {
                _naturel.Cosmetic.Add(new Cosmetic()
                {
                    Number = Convert.ToInt32(TxtNumber.Text),
                    Name = TxtNameCosmetics.Text,
                    Date_manu = Manufacture.DisplayDate,
                    Expiration = Expiration.DisplayDate,
                    Price = Convert.ToInt32(TxtPrice.Text)
                });
                _naturel.SaveChanges();
                _window.RefreshCosmetica();

                this.Close();
            }
        }
    }
}
