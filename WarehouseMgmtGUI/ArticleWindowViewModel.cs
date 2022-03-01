using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    public class ArticleWindowViewModel :BaseViewModel
    {
   

        public ArticleWindowViewModel()
        {
            this.AddArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBBL art = new ArticleBBL();
                    int id = art.AddArticle(newArticle.Name, newArticle.Price);
                    newArticle.Id = id;
                    this.Articles.Add(newArticle);
                    NewArticle = new ArticleBBL();

                   
                });

            this.ListArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBBL art = new ArticleBBL();

                    var list = art.GetArticles();
                    this.Articles = new ObservableCollection<ArticleBBL>();
                    foreach (ArticleBBL item in list)
                    {
                        this.Articles.Add(item);
                    }

                });

        }

        ArticleBBL newArticle = new ArticleBBL();

        public ArticleBBL NewArticle
        {
            get => newArticle;
            set
            {
                if (newArticle != value)
                {
                    newArticle = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<ArticleBBL> articles = new ObservableCollection<ArticleBBL>();

        public ObservableCollection<ArticleBBL> Articles
        {
            get => articles;
            set
            {
                if (articles != value)
                {
                    articles = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand AddArticleCommand { get; set; }
        public DelegateCommand ListArticleCommand { get; set; }

    }
}
