using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    /// <summary>
    /// Interaktionslogik für ArticleGroupWindow.xaml
    /// </summary>
    public partial class ArticleGroupWindow : Window
    {
        ArticleBLL articleBLL = new ArticleBLL();
        public ArticleGroupWindow()
        {
            InitializeComponent();

            ReturnSelectedGroupButton.Visibility = Visibility.Hidden;
        }


        public ArticleGroupWindow(ArticleBLL articleBLL)
        {
            InitializeComponent();

            this.articleBLL = articleBLL;

            this.DataContext = new ArticleGroupWindowViewModel(articleBLL);

        }

        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ReturnSelectedGroupButton_Click(object sender, RoutedEventArgs e)
        {
            //articleBLL.ArticleGroupId = Convert.ToInt32(ArticleGroupIdTextBox.Text);
            this.Close();
        }
        
    }
}
