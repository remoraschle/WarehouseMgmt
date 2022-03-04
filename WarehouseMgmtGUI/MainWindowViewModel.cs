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

            this.ViewsCommand = new DelegateCommand((o) =>
            {
                
            });

            this.TestDataCommand = new DelegateCommand((o) =>
            {
                CustomerBLL customer = new CustomerBLL();
                int customer1 = customer.AddCustomer("Max", "Muster", "Habichtstrasse 40", "9220","Bischofszell", "Max.Muster@gmx.ch", "www.Max.com", "34sssssss");
                customer.AddCustomer("Tasd", "Ass", "JStasse 33", "9220", "Bischofszell", "Adasdf@gmx.ch", "www.rttg.com", "asdfasdf");
                customer.AddCustomer("Tss", "JHhh", "Haltstrasse 74", "9220", "Bischofszell", "asdfr@gmx.ch", "www.asdf.com", "sdbdf");
                customer.AddCustomer("ASss", "Addh", "Neinstrasse 12", "9220", "Bischofszell", "bdnfgr@gmx.ch", "www.jfhmfgh.com", "asdvrweg");
                customer.AddCustomer("Tsdfg", "Zkl", "Fussstrasse 44", "9220", "Bischofszell", "sdfgs@gmx.ch", "www.asdfasdf.com", "asdfqwe");
                customer.AddCustomer("Sebastian", "Vettel");
                customer.AddCustomer("Albert", "Einstein");


                ArticleGroupBLL articleGroupBLL = new ArticleGroupBLL();
                int foodGroup = articleGroupBLL.AddArticleGroup("Food", null);
                int fluidGroup = articleGroupBLL.AddArticleGroup("Fluid", foodGroup);
                int solidGroup = articleGroupBLL.AddArticleGroup("Solid", foodGroup);
                int randomGroup = articleGroupBLL.AddArticleGroup("Somthingelse", null);

                ArticleBLL article = new ArticleBLL();
                article.AddArticle("Rahmspinat", (decimal)5.25, solidGroup);
                article.AddArticle("Pilz Suppe", (decimal)3.42, fluidGroup);
                article.AddArticle("IceTee", (decimal)2.99, fluidGroup);
                article.AddArticle("OrangeTee", (decimal)2.89, fluidGroup);
                article.AddArticle("Pizza", (decimal)8, solidGroup);
                article.AddArticle("Nudeln", (decimal)1.11, solidGroup);
                article.AddArticle("Wasser", (decimal)0.25, fluidGroup);
                article.AddArticle("Tisch", (decimal)552.68, randomGroup);



                OrderBLL orderBLL = new OrderBLL();
                orderBLL.AddOrder(DateTime.Now, customer1);


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
