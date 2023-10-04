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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Natural
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NaturelEntities _naturel = new NaturelEntities();
        private List<Cosmetic> _cosmetics = new List<Cosmetic>();
        private string _FindedName;
        public MainWindow()
        {
            InitializeComponent();
            ListCosmetic.ItemsSource = _naturel.Cosmetic.OrderBy(Cosmetic => Cosmetic.Name).ToList();
        }
        private void TxtFindedCosmeticName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _FindedName = TxtFindedCosmeticName.Text;

            _cosmetics = _naturel.Cosmetic.OrderBy(c => c.Name).ToList();

            if (TxtFindedCosmeticName.Text != "")
            {
                _cosmetics = _cosmetics.OrderBy(c => c.Name).Where(c => c.Name.ToLower().Contains(_FindedName)).ToList();
            }
            else
            {
                _cosmetics = _naturel.Cosmetic.ToList();
            }
            ListCosmetic.ItemsSource = _cosmetics;
        }

        private void TbAkkaunt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AkkauntUser au = new AkkauntUser();
            au.Show();
        }

        /*public string FullViewPrice
        {
            get
            {
                return Convert.ToString(this.Price) + "Р.";
            }
        }
        public string ImgPath
        {
            get
            {
                return "/Resources/" + this.Name + ".jpg";
            }
        }*/
    }
}
