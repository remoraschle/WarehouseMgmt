using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;
using WarehouseMgmtDB.Model;

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
                    NewArticle = new Article();

                   
                });

            this.ListArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBBL art = new ArticleBBL();

                    var list = art.GetArticles();
                    this.Articles = null;
                    foreach (Article item in list)
                    {
                        this.Articles.Add(item);
                    }

                });

        }

        Article newArticle = new Article();

        public Article NewArticle
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

        private ObservableCollection<Article> articles = new ObservableCollection<Article>();

        public ObservableCollection<Article> Articles
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
