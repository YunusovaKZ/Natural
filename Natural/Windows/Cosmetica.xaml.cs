using Natural.Windows;
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
    /// Логика взаимодействия для Cosmetica.xaml
    /// </summary>
    public partial class Cosmetica : Window
    {
        public static NaturelEntities _naturel = new NaturelEntities();
        private int _currentPage = 1;
        private int _maxPage = 0;
        public Cosmetica()
        {
            InitializeComponent();

            RefreshCosmetica();
        }

        public void RefreshCosmetica()
        {
            DataGridCosmetica.ItemsSource = _naturel.Cosmetic.OrderBy(c => c.Name).ToList();
            _maxPage = Convert.ToInt32(Math.Ceiling(_naturel.Cosmetic.ToList().Count * 1.0 / 10));

            var listCosmetica = _naturel.Cosmetic.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            LbTotalPages.Content = "of " + _maxPage.ToString();
            TxtCurrentPageNumber.Text = _currentPage.ToString();
            DataGridCosmetica.ItemsSource = listCosmetica;
        }

        private void BtnEditCosmetic_Click(object sender, RoutedEventArgs e)
        {

            EditCosmetics editCosmetics = new EditCosmetics(_naturel, sender, this);
            editCosmetics.ShowDialog();
        }

        private void TbAkkaunt_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {   
            AkkauntSeller ak = new AkkauntSeller();
            ak.Show();
        }

        /// <summary>
        /// Переход к первой странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshCosmetica();
        }

        /// <summary>
        /// Переход к предыдущей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoPrevPage_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage - 1 < 1)
            {
                return;
            }
            _currentPage = _currentPage - 1;
            RefreshCosmetica();
        }

        /// <summary>
        /// Переход к следующей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoNextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_currentPage +1>_maxPage)
            {
                return;
            }
            _currentPage = _currentPage + 1;
            RefreshCosmetica();
        }

        /// <summary>
        /// Переход к последней странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshCosmetica();
        }

        private void BtnAddCosmetic_Click(object sender, RoutedEventArgs e)
        {
            AddCosmetics addCosmetics = new AddCosmetics(_naturel, this);
            addCosmetics.ShowDialog();
        }
    }
}
