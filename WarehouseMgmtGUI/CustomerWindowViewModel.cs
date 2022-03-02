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
            this.AddCustomerCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                CustomerBLL art = new CustomerBLL();
                int id = art.AddCustomer(newCustomer.FirstName,newCustomer.LastName, newCustomer.Street, newCustomer.Zip, newCustomer.City, newCustomer.Mail, newCustomer.Url, newCustomer.Password);
                newCustomer.Id = id;
                this.Customers.Add(newCustomer);
                NewCustomer = new CustomerBLL();


            });

            this.SaveCustomerCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedCustomer != null)
                {
                    bool save = selectedCustomer.EditCustomer(newCustomer);


                    //// Daten werden in der Liste nicht aktualisiert. Dafür müsste man in der CustomerBLL ebenfalls eine RaisePropertyChanged() implementieren
                    //var a = Customers.FirstOrDefault(x => x == selectedCustomer);
                    //a.Name = newCustomer.Name;
                    //a.Price = newCustomer.Price;

                    NewCustomer = new CustomerBLL();
                }
            });

            this.SearchCustomerCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

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
            });

            this.DeleteCustomerCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedCustomer != null)
                {
                    bool save = selectedCustomer.DeleteCustomer(newCustomer);

                    Customers.Remove(selectedCustomer);

                    NewCustomer = new CustomerBLL();
                }
            });


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
    }
}
