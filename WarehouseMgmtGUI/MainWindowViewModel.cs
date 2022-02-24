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


        }

        public DelegateCommand CustomerCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }



        private void CustomerWindow()
        {
            Customer customer = new Customer();
            customer.Show();
        }

        private void SearchCustomer()
        {

        }


    }
}
