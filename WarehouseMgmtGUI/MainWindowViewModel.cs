using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtGUI
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            this.CustomerCommand = new DelegateCommand((o) => CustomerWindow());

            this.SearchCommand = new DelegateCommand((o) => SearchCustomer());

            this.ArticleCommand = new DelegateCommand((o) => ArticleWindow());

        }

        public DelegateCommand CustomerCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand ArticleCommand { get; set; }


        private void CustomerWindow()
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void ArticleWindow()
        {
            ArticleWindow articleWindow = new ArticleWindow();
            articleWindow.Show();
        }

        private void SearchCustomer()
        {

        }


    }
}
