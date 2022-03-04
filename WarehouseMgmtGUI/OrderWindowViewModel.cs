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
    public class OrderWindowViewModel : NotifyableBaseObject
    {
        public OrderWindowViewModel()
        {
            this.AddOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                OrderBLL ord = new OrderBLL();
                int id = ord.AddOrder(DateTime.Now, newOrder.CustomerId, newOrder.OrderPositionsId);
                newOrder.Id = id;
                this.Orders.Add(newOrder);
                NewOrder = new OrderBLL();


            });

            this.SaveOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedOrder != null)
                {
                    bool save = selectedOrder.EditOrder(NewOrder);

                    NewOrder = new OrderBLL
                    {
                        Id = NewOrder.Id,
                        Date = NewOrder.Date,
                        CustomerId = NewOrder.CustomerId,
                        CustomerName = NewOrder.CustomerName,
                        OrderPositionsId = NewOrder.OrderPositionsId
                    };


                    //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in OrderBLL on each Object
                    //therefore we just reload the whole List :-D

                    OrderBLL cust = new OrderBLL();

                    var list = cust.GetOrders(newOrder.SearchOrderNumber, newOrder.SearchOrderDate);

                    this.Orders = new ObservableCollection<OrderBLL>();

                    if (list != null)
                    {
                        foreach (OrderBLL item in list)
                        {
                            this.Orders.Add(item);
                        }
                    }

                    //Reselect after reloading the list
                    SelectedOrder = NewOrder;
                }
            });

            this.SearchOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                OrderBLL cust = new OrderBLL();

                var list = cust.GetOrders(newOrder.SearchOrderNumber, newOrder.SearchOrderDate);

                this.Orders = new ObservableCollection<OrderBLL>();

                if (list != null)
                {
                    foreach (OrderBLL item in list)
                    {
                        this.Orders.Add(item);
                    }
                }
            });

            this.DeleteOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedOrder != null)
                {
                    bool save = selectedOrder.DeleteOrder(newOrder);

                    Orders.Remove(selectedOrder);

                    NewOrder = new OrderBLL();
                }
            });

            this.SelectCustomerCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click
                if (NewOrder != null)//&& NewOrder.Id != 0
                {
                    CustomerWindow customerWindow = new CustomerWindow(NewOrder);
                    customerWindow.ShowDialog();

                    NewOrder = new OrderBLL
                    {
                        Id = NewOrder.Id,
                        Date = NewOrder.Date,
                        CustomerId = NewOrder.CustomerId,
                        CustomerName = NewOrder.CustomerName,
                        OrderPositionsId = NewOrder.OrderPositionsId
                    };
                }

            });


        }

        OrderBLL newOrder = new OrderBLL();

        public OrderBLL NewOrder
        {
            get => newOrder;
            set
            {
                if (newOrder != value)
                {
                    newOrder = value;
                    this.RaisePropertyChanged();
                }
            }
        }


        OrderBLL selectedOrder = new OrderBLL();

        public OrderBLL SelectedOrder
        {
            get => selectedOrder;
            set
            {
                if (selectedOrder != value)
                {
                    selectedOrder = value;

                    if (selectedOrder != null)
                    {
                        NewOrder = new OrderBLL
                        {
                            Id = selectedOrder.Id,
                            Date = selectedOrder.Date,
                            CustomerId = selectedOrder.CustomerId,
                            CustomerName = selectedOrder.CustomerName,
                            OrderPositionsId = selectedOrder.OrderPositionsId
                        };
                    }

                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<OrderBLL> orders = new ObservableCollection<OrderBLL>();

        public ObservableCollection<OrderBLL> Orders
        {
            get => orders;
            set
            {
                if (orders != value)
                {
                    orders = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand AddOrderCommand { get; set; }
        public DelegateCommand SaveOrderCommand { get; set; }
        public DelegateCommand SearchOrderCommand { get; set; }
        public DelegateCommand DeleteOrderCommand { get; set; }
        public DelegateCommand SelectCustomerCommand { get; set; }
    }
}
