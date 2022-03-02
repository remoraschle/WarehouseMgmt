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

                OrderBLL art = new OrderBLL();
                int id = art.AddOrder(newOrder.Date, newOrder.CustomerId, newOrder.OrderPositionsId);
                newOrder.Id = id;
                this.Orders.Add(newOrder);
                NewOrder = new OrderBLL();


            });

            this.SaveOrderCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedOrder != null)
                {
                    bool save = selectedOrder.EditOrder(newOrder);


                    //// Daten werden in der Liste nicht aktualisiert. Dafür müsste man in der OrderBLL ebenfalls eine RaisePropertyChanged() implementieren
                    //var a = Orders.FirstOrDefault(x => x == selectedOrder);
                    //a.Name = newOrder.Name;
                    //a.Price = newOrder.Price;

                    NewOrder = new OrderBLL();
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
    }
}
