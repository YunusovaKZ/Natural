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
    /// Логика взаимодействия для MenedgerWorkUser.xaml
    /// </summary>
    public partial class MenedgerWorkUser : Window
    {
        public static NaturelEntities _naturel = new NaturelEntities();
        private int _currentPage = 1;
        private int _maxPage = 0;
        public MenedgerWorkUser()
        {
            InitializeComponent();

            RefreshBuyer();
        }

        public void RefreshBuyer()
        {
            DataGridUsers.ItemsSource = _naturel.Buyer.OrderBy(c => c.Name).ToList();
            _maxPage = Convert.ToInt32(Math.Ceiling(_naturel.Buyer.ToList().Count * 1.0 / 10));

            var listUser = _naturel.Buyer.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            LbTotalPages.Content = "of " + _maxPage.ToString();
            TxtCurrentPageNumber.Text = _currentPage.ToString();
            DataGridUsers.ItemsSource = listUser;
        }

        /// <summary>
        /// Переход к первой странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshBuyer();
        }

        /// <summary>
        /// Переход к предыдущей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoPrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
            {
                return;
            }
            _currentPage = _currentPage - 1;
            RefreshBuyer();
        }

        /// <summary>
        /// Переход к следующей странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoNextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage + 1 > _maxPage)
            {
                return;
            }
            _currentPage = _currentPage + 1;
            RefreshBuyer();
        }

        /// <summary>
        /// Переход к последней странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGoLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshBuyer();
        }

        private void TbAkkaunt_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            AkkauntMeneger ak = new AkkauntMeneger();
            ak.Show();
        }
    }
}
