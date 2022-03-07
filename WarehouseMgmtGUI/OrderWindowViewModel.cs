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
            #region Order
            this.AddOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                OrderBLL ord = new OrderBLL();
                int id = ord.AddOrder(DateTime.Now, newOrder.CustomerId);
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
                        CustomerName = NewOrder.CustomerName
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
                        CustomerName = NewOrder.CustomerName
                    };
                }

            });
            #endregion





            #region OrderPosition

            this.AddOrderPositionCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                OrderPositionsBLL ord = new OrderPositionsBLL();
                ord.AddOrderPosition(NewOrderPosition.OrderId, NewOrderPosition.ArticleId, NewOrderPosition.Quantity);

                this.OrdersPosition.Add(NewOrderPosition);
                NewOrder = new OrderBLL();


            });

            this.SaveOrderPositionCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedOrderPosition != null)
                {
                    bool save = selectedOrderPosition.EditOrderPosition(NewOrderPosition);
                    if (save)
                    {


                        NewOrderPosition = new OrderPositionsBLL
                        {
                            OrderId = NewOrderPosition.OrderId,
                            ArticleId = NewOrderPosition.ArticleId,
                            Quantity = NewOrderPosition.Quantity
                        };
                    }

                    //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in OrderBLL on each Object
                    //therefore we just reload the whole List :-D

                    // Load OrderPositions
                    GetOrderPosition();

                    //Reselect after reloading the list
                    SelectedOrderPosition = NewOrderPosition;
                }
            });



            this.DeleteOrderPositionCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedOrderPosition != null)
                {
                    bool save = selectedOrderPosition.DeleteOrderPosition(newOrderPosition);

                    OrdersPosition.Remove(selectedOrderPosition);

                    NewOrderPosition = new OrderPositionsBLL();
                }
            });


            this.SelectArticleCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click
                if (NewOrderPosition != null)//&& NewOrder.Id != 0
                {
                    ArticleWindow articleWindow = new ArticleWindow(NewOrderPosition);
                    articleWindow.ShowDialog();

                    NewOrderPosition = new OrderPositionsBLL
                    {
                        ArticleId = NewOrderPosition.ArticleId,
                        OrderId = NewOrderPosition.OrderId,
                        ArticleName = NewOrderPosition.ArticleName,
                        Quantity = NewOrderPosition.Quantity
                    };
                }

            });
            #endregion


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
                            CustomerName = selectedOrder.CustomerName
                        };


                        // Load OrderPositions
                        GetOrderPosition();
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



        OrderPositionsBLL newOrderPosition = new OrderPositionsBLL();

        public OrderPositionsBLL NewOrderPosition
        {
            get => newOrderPosition;
            set
            {
                if (newOrderPosition != value)
                {
                    newOrderPosition = value;
                    this.RaisePropertyChanged();
                }
            }
        }


        OrderPositionsBLL selectedOrderPosition = new OrderPositionsBLL();

        public OrderPositionsBLL SelectedOrderPosition
        {
            get => selectedOrderPosition;
            set
            {
                if (selectedOrderPosition != value)
                {
                    selectedOrderPosition = value;

                    if (selectedOrderPosition != null)
                    {
                        NewOrderPosition = new OrderPositionsBLL
                        {
                            ArticleId = SelectedOrderPosition.ArticleId,
                            OrderId = SelectedOrderPosition.OrderId,
                            ArticleName = SelectedOrderPosition.ArticleName,
                            Quantity = SelectedOrderPosition.Quantity
                        };
                    }

                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<OrderPositionsBLL> ordersPosition = new ObservableCollection<OrderPositionsBLL>();

        public ObservableCollection<OrderPositionsBLL> OrdersPosition
        {
            get => ordersPosition;
            set
            {
                if (ordersPosition != value)
                {
                    ordersPosition = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        private void GetOrderPosition()
        {
            OrderPositionsBLL orderPositionsBLL = new OrderPositionsBLL();

            var list = orderPositionsBLL.GetOrderPositions(SelectedOrder.Id);

            this.OrdersPosition = new ObservableCollection<OrderPositionsBLL>();

            if (list != null)
            {
                foreach (OrderPositionsBLL item in list)
                {
                    this.OrdersPosition.Add(item);
                }
            }

            NewOrderPosition = new OrderPositionsBLL
            {
                OrderId = SelectedOrder.Id,
            };
        }


        public DelegateCommand AddOrderCommand { get; set; }
        public DelegateCommand SaveOrderCommand { get; set; }
        public DelegateCommand SearchOrderCommand { get; set; }
        public DelegateCommand DeleteOrderCommand { get; set; }
        public DelegateCommand SelectCustomerCommand { get; set; }


        public DelegateCommand AddOrderPositionCommand { get; set; }
        public DelegateCommand SaveOrderPositionCommand { get; set; }
        public DelegateCommand DeleteOrderPositionCommand { get; set; }
        public DelegateCommand SelectArticleCommand { get; set; }
    }
}
