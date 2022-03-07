using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;
using WarehouseMgmtDB;

namespace WarehouseMgmtGUI
{
    public class MainWindowViewModel : NotifyableBaseObject
    {
        public MainWindowViewModel()
        {
            this.CustomerCommand = new DelegateCommand((o) =>
            {
                CustomerWindow customer = new CustomerWindow();
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

            this.BillViewsCommand = new DelegateCommand((o) =>
            {
                BillViewWindow billViewWindow = new BillViewWindow();
                billViewWindow.Show();

            });

            this.ArticleGroupViewsCommand = new DelegateCommand((o) =>
            {
                ArticleGroupTreeView articleGroupViewWindow = new ArticleGroupTreeView();
                articleGroupViewWindow.Show();

            });

            this.TestDataCommand = new DelegateCommand((o) =>
            {
                CustomerBLL customer = new CustomerBLL();
                int customer1 = customer.AddCustomer("Max", "Muster", "Habichtstrasse 40", "9220","Bischofszell", "Max.Muster@gmx.ch", "www.Max.com", "34sssssss");
                int customer2 = customer.AddCustomer("Tasd", "Ass", "JStasse 33", "9220", "Bischofszell", "Adasdf@gmx.ch", "www.rttg.com", "asdfasdf");
                int customer3 = customer.AddCustomer("Tss", "JHhh", "Haltstrasse 74", "9220", "Bischofszell", "asdfr@gmx.ch", "www.asdf.com", "sdbdf");
                int customer4 = customer.AddCustomer("ASss", "Addh", "Neinstrasse 12", "9220", "Bischofszell", "bdnfgr@gmx.ch", "www.jfhmfgh.com", "asdvrweg");
                int customer5 = customer.AddCustomer("Tsdfg", "Zkl", "Fussstrasse 44", "9220", "Bischofszell", "sdfgs@gmx.ch", "www.asdfasdf.com", "asdfqwe");
                int customer6 = customer.AddCustomer("Sebastian", "Vettel");
                int customer7 = customer.AddCustomer("Albert", "Einstein");


                ArticleGroupBLL articleGroupBLL = new ArticleGroupBLL();
                int foodGroup = articleGroupBLL.AddArticleGroup("Food", null);
                int fluidGroup = articleGroupBLL.AddArticleGroup("Fluid", foodGroup);
                int solidGroup = articleGroupBLL.AddArticleGroup("Solid", foodGroup);
                int randomGroup = articleGroupBLL.AddArticleGroup("Somthingelse", null);

                ArticleBLL article = new ArticleBLL();
                int article1 = article.AddArticle("Rahmspinat", (decimal)5.25, solidGroup);
                int article2 = article.AddArticle("Pilz Suppe", (decimal)3.42, fluidGroup);
                int article3 = article.AddArticle("IceTee", (decimal)2.99, fluidGroup);
                int article4 = article.AddArticle("OrangeTee", (decimal)2.89, fluidGroup);
                int article5 = article.AddArticle("Pizza", (decimal)8, solidGroup);
                int article6 = article.AddArticle("Nudeln", (decimal)1.11, solidGroup);
                int article7 = article.AddArticle("Wasser", (decimal)0.25, fluidGroup);
                int article8 = article.AddArticle("Tisch", (decimal)552.68, randomGroup);



                OrderBLL orderBLL = new OrderBLL();
                int order1 = orderBLL.AddOrder(DateTime.Now, customer1);
                int order2 = orderBLL.AddOrder(DateTime.Now, customer4);


                List<OrderPositionsBLL> orderPositionsBLL = new List<OrderPositionsBLL>{ 
                    new OrderPositionsBLL { ArticleId = article1, OrderId = order1, Quantity = 20 },
                    new OrderPositionsBLL { ArticleId = article2, OrderId = order1, Quantity = 50 },
                    new OrderPositionsBLL { ArticleId = article3, OrderId = order1, Quantity = 2 },
                    new OrderPositionsBLL { ArticleId = article4, OrderId = order1, Quantity = 20 },
                    new OrderPositionsBLL { ArticleId = article4, OrderId = order2, Quantity = 100 },
                    new OrderPositionsBLL { ArticleId = article1, OrderId = order2, Quantity = 33 }

                };

                orderBLL.AddArticlesToOrder(orderPositionsBLL);

            });


        }

        public DelegateCommand CustomerCommand { get; set; }
        public DelegateCommand ArticleCommand { get; set; }
        public DelegateCommand ArticleGroupsCommand { get; set; }
        public DelegateCommand OrdersCommand { get; set; }
        public DelegateCommand BillViewsCommand { get; set; }
        public DelegateCommand ArticleGroupViewsCommand { get; set; }
        public DelegateCommand TestDataCommand { get; set; }




    }
}
