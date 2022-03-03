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
                ArticleGroupWindow articleGroupWindow = new ArticleGroupWindow();
                articleGroupWindow.Show();

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



                ArticleBLL article = new ArticleBLL();
                article.AddArticle("Rahmspinat", (decimal)5.25);
                article.AddArticle("Pilz Suppe", (decimal)3.42);
                article.AddArticle("IceTee", (decimal)2.99);
                article.AddArticle("OrangeTee", (decimal)2.89);
                article.AddArticle("Pizza", (decimal)8);
                article.AddArticle("Nudeln", (decimal)1.11);
                article.AddArticle("Wasser", (decimal)0.25);


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
