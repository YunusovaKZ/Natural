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
using Microsoft.Win32;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Natural.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditCosmetics.xaml
    /// </summary>
    public partial class EditCosmetics : Window
    {
        private NaturelEntities _naturel;
        private Cosmetic _cosmetic;
        private Cosmetica _window;
        public EditCosmetics(NaturelEntities naturel, object o, Cosmetica cosmetica)
        {
            InitializeComponent();
            _cosmetic = (o as Button).DataContext as Cosmetic;
            _naturel = naturel;

            _window = cosmetica;

            TxtNumber.Text = Convert.ToString(_cosmetic.Number);
            TxtNameCosmetics.Text = _cosmetic.Name;
            Manufacture.SelectedDate = _cosmetic.Date_manu;
            Expiration.SelectedDate = _cosmetic.Expiration;
            TxtPrice.Text = Convert.ToString(_cosmetic.Price);
        }

        private void BtnDeleteCosmetic_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(_cosmetic.Name, "Вы хотите удалить продукт?", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                _naturel.Cosmetic.Remove(_cosmetic);
                _naturel.SaveChanges();

                _window.RefreshCosmetica();
                this.Close();
            }
        }

        private void BtnUpdateCosmetic_Click(object sender, RoutedEventArgs e)
        {
            _cosmetic.Number = Convert.ToInt32(TxtNumber.Text);
            _cosmetic.Name = TxtNameCosmetics.Text;
            _cosmetic.Date_manu = Manufacture.DisplayDate;
            _cosmetic.Expiration = Expiration.DisplayDate;
            _cosmetic.Price = Convert.ToInt32(TxtPrice.Text);

            _window.RefreshCosmetica();
            _naturel.SaveChanges();
            this.Close();
        }
    }
}
