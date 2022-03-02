using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    public class MainWindowViewModel : NotifyableBaseObject
    {
        public MainWindowViewModel()
        {
            this.CustomerCommand = new DelegateCommand((o) =>
            {
                Customer customer = new Customer();
                customer.Show();
            });

            this.ArticleCommand = new DelegateCommand((o) =>
            {
                ArticleWindow articleWindow = new ArticleWindow();
                articleWindow.Show();
            });

            this.ArticleGroupsCommand = new DelegateCommand((o) =>
            {

            });

            this.OrdersCommand = new DelegateCommand((o) =>
            {
                OrderWindow orderWindow = new OrderWindow();
                orderWindow.Show();
            });

            this.ViewsCommand = new DelegateCommand((o) =>
            {
                
            });

            this.TestDataCommand = new DelegateCommand((o) =>
            {
                CustomerBLL customer = new CustomerBLL();
                customer.AddCustomer("Max", "Muster", "Habichtstrasse 40", "9220","Bischofszell", "Max.Muster@gmx.ch", "www.Max.com", "34sssssss");
                customer.AddCustomer("Tasd", "Ass", "JStasse 33", "9220", "Bischofszell", "Adasdf@gmx.ch", "www.rttg.com", "asdfasdf");
                customer.AddCustomer("Tss", "JHhh", "Haltstrasse 74", "9220", "Bischofszell", "asdfr@gmx.ch", "www.asdf.com", "sdbdf");
                customer.AddCustomer("ASss", "Addh", "Neinstrasse 12", "9220", "Bischofszell", "bdnfgr@gmx.ch", "www.jfhmfgh.com", "asdvrweg");
                customer.AddCustomer("Tsdfg", "Zkl", "Fussstrasse 44", "9220", "Bischofszell", "sdfgs@gmx.ch", "www.asdfasdf.com", "asdfqwe");
                customer.AddCustomer("Sebastian", "Vettel");
                customer.AddCustomer("Albert", "Einstein");

            });

        }

        public DelegateCommand CustomerCommand { get; set; }
        public DelegateCommand ArticleCommand { get; set; }
        public DelegateCommand ArticleGroupsCommand { get; set; }
        public DelegateCommand OrdersCommand { get; set; }
        public DelegateCommand ViewsCommand { get; set; }
        public DelegateCommand TestDataCommand { get; set; }


    


    }
}
