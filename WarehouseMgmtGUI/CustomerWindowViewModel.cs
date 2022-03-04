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
            this.AddCustomerCommand = new DelegateCommand((o) => AddCustomer());

            this.SaveCustomerCommand = new DelegateCommand((o) => SaveCustomer());

            this.SearchCustomerCommand = new DelegateCommand((o) => SearchCustomer());

            this.DeleteCustomerCommand = new DelegateCommand((o) => DeleteCustomer());

        }

        public CustomerWindowViewModel(OrderBLL orderBLL)
        {
            if (orderBLL != null)
            {

                this.AddCustomerCommand = new DelegateCommand((o) => AddCustomer());

                this.SaveCustomerCommand = new DelegateCommand((o) => SaveCustomer());

                this.SearchCustomerCommand = new DelegateCommand((o) => SearchCustomer());

                this.DeleteCustomerCommand = new DelegateCommand((o) => DeleteCustomer());


                this.ChangeCustomerInOrdersCommand = new DelegateCommand((o) =>
                {
                    orderBLL.Customer = NewCustomer;
                    orderBLL.CustomerId = NewCustomer.Id;
                    orderBLL.CustomerName = NewCustomer.FirstName + " " + NewCustomer.LastName;
                });



                if (orderBLL != null)
                {
                    CustomerBLL cust = new CustomerBLL();

                    if (orderBLL.Customer != null)
                    {
                        var customer = cust.GetCustomer(orderBLL.CustomerId, null).FirstOrDefault();
                        if (customer != null)
                        {
                            NewCustomer = customer;
                        }
                    }
                    else
                    {
                        NewCustomer = cust;
                    }
                    
                }
            }

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


        CustomerBLL selectedCustomer = new CustomerBLL();

        public CustomerBLL SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                if (selectedCustomer != value)
                {
                    selectedCustomer = value;

                    if (selectedCustomer != null)
                    {
                        NewCustomer = new CustomerBLL
                        {
                            Id = selectedCustomer.Id,
                            FirstName = selectedCustomer.FirstName,
                            LastName = selectedCustomer.LastName,
                            Street = selectedCustomer.Street,
                            Zip = selectedCustomer.Zip,
                            City = selectedCustomer.City,
                            Mail = selectedCustomer.Mail,
                            Url = selectedCustomer.Url,
                            Password = selectedCustomer.Password
                        };
                    }

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

        public DelegateCommand AddCustomerCommand { get; set; }
        public DelegateCommand SaveCustomerCommand { get; set; }
        public DelegateCommand SearchCustomerCommand { get; set; }
        public DelegateCommand DeleteCustomerCommand { get; set; }
        public DelegateCommand ChangeCustomerInOrdersCommand { get; set; }


        private void AddCustomer()
        {
            CustomerBLL art = new CustomerBLL();
            int id = art.AddCustomer(newCustomer.FirstName, newCustomer.LastName, newCustomer.Street, newCustomer.Zip, newCustomer.City, newCustomer.Mail, newCustomer.Url, newCustomer.Password);
            newCustomer.Id = id;
            this.Customers.Add(newCustomer);
            NewCustomer = new CustomerBLL();
        }

        private void SaveCustomer()
        {
            if (selectedCustomer != null)
            {
                bool save = selectedCustomer.EditCustomer(newCustomer);


                //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in CustomerBLL on each Object
                //therefore we just reload the whole List :-D
                SearchCustomer();

                //Reselect after reloading
                SelectedCustomer = NewCustomer;
            }
        }

        private void SearchCustomer()
        {
            CustomerBLL cust = new CustomerBLL();

            var list = cust.GetCustomer(newCustomer.SearchCustomerNumber, newCustomer.SearchCustomerName);

            this.Customers = new ObservableCollection<CustomerBLL>();

            if (list != null)
            {
                foreach (CustomerBLL item in list)
                {
                    this.Customers.Add(item);
                }
            }
        }

        private void DeleteCustomer()
        {
            if (selectedCustomer != null)
            {
                bool save = selectedCustomer.DeleteCustomer(newCustomer);

                Customers.Remove(selectedCustomer);

                //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in CustomerBLL on each Object
                //therefore we just reload the whole List :-D

                SearchCustomer();

                NewCustomer = new CustomerBLL();
            }
        }

    }
}
