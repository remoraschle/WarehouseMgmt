using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WarehouseMgmtBL;
using System.Collections.ObjectModel;

namespace WarehouseMgmtGUI
{
    public class CustomerWindowViewModel : NotifyableBaseObject
    {
        public CustomerWindowViewModel()
        {
            CustomerNumber = 1;
            CustomerName = "Name";
            CustomerStreet = "Strasse";
            CustomerPLZ = "1111";
            CustomerLocation = "SG";
            CustomerMail = "Max.Mustermann@gmail.com";
            CustomerWebsite = "google.ch";
            CustomerPW = "1234";

            this.SaveCommand = new DelegateCommand((o) => SaveCustomer());

            this.SearchCustomerCommand = new DelegateCommand((o) => SearchCustomer());
        }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand SearchCustomerCommand { get; set; }
        public DelegateCommand ChangeCustomerCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerPLZ { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerWebsite { get; set; }
        public string CustomerPW { get; set; }


        public int SearchCustomerNumber { get; set; }
        public string SearchCustomerName { get; set; }
   

        string saveTest;
        public string SaveTest
        {
            get => saveTest;
            set
            {
                if (saveTest != value)
                {
                    saveTest = value;
                    this.RaisePropertyChanged();
                    this.SaveCommand.RaiseCanExecuteChanged(); 
                }
            }
        }

        private void SaveCustomer()
        {
            //CustomerBLL art = new CustomerBLL();
            //int id = art.AddCusomer(newCustomer.Name, newCustomer.Price);
            //newCustomer.Id = id;
            //this.Customers.Add(newCustomer);
            //NewCustomer = new CustomerBLL();
        }

        private void SearchCustomer()
        {
            //CustomerBLL cust = new CustomerBLL();

            //var list = cust.GetCustomers();
            //this.Customers = new ObservableCollection<CustomerBLL>();
            //foreach (CustomerBLL item in list)
            //{
            //    this.Customers.Add(item);
            //}
        }


        CustomerBLL newCustomer = new CustomerBLL();

        public CustomerBLL NewCustomer
        {
            get => newCustomer;
            set
            {
                if (newCustomer != value)
                {
                    newCustomer = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<CustomerBLL> customers = new ObservableCollection<CustomerBLL>();

        public ObservableCollection<CustomerBLL> Customers
        {
            get => customers;
            set
            {
                if (customers != value)
                {
                    customers = value;
                    this.RaisePropertyChanged();
                }
            }
        }
    }
}
