using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    public class ArticleWindowViewModel : NotifyableBaseObject
    {
        public ArticleWindowViewModel()
        {
            this.AddArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBLL art = new ArticleBLL();
                    int id = art.AddArticle(newArticle.Name, newArticle.Price);
                    newArticle.Id = id;
                    this.Articles.Add(newArticle);
                    NewArticle = new ArticleBLL();

                   
                });

            this.SaveArticleCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedArticle != null)
                {
                    bool save = selectedArticle.EditArticle(newArticle);


                    //// Daten werden in der Liste nicht aktualisiert. Dafür müsste man in der ArticleBLL ebenfalls eine RaisePropertyChanged() implementieren
                    //var a = Articles.FirstOrDefault(x => x == selectedArticle);
                    //a.Name = newArticle.Name;
                    //a.Price = newArticle.Price;

                    NewArticle = new ArticleBLL();
                }
            });

            this.SearchArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBLL art = new ArticleBLL();

                    var list = art.GetArticles(newArticle.SearchArticleNumber, newArticle.SearchArticleName);

                    this.Articles = new ObservableCollection<ArticleBLL>();

                    if (list != null)
                    {
                        foreach (ArticleBLL item in list)
                        {
                            this.Articles.Add(item);
                        }
                    }
                });

            this.DeleteArticleCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click

                if (selectedArticle != null)
                {
                    bool save = selectedArticle.DeleteArticle(newArticle);

                    Articles.Remove(selectedArticle);

                    NewArticle = new ArticleBLL();
                }
            });


        }

        ArticleBLL newArticle = new ArticleBLL();

        public ArticleBLL NewArticle
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


        ArticleBLL selectedArticle = new ArticleBLL();

        public ArticleBLL SelectedArticle
        {
            get => selectedArticle;
            set
            {
                if (selectedArticle != value)
                {
                    selectedArticle = value;

                    if (selectedArticle != null)
                    {
                        NewArticle = new ArticleBLL
                        {
                            Id = selectedArticle.Id,
                            Name = selectedArticle.Name,
                            Price = selectedArticle.Price,
                            ArticleGroupId = selectedArticle.ArticleGroupId,
                            ArticleGroup = selectedArticle.ArticleGroup
                        };
                    }

                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<ArticleBLL> articles = new ObservableCollection<ArticleBLL>();

        public ObservableCollection<ArticleBLL> Articles
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
        public DelegateCommand SaveArticleCommand { get; set; }
        public DelegateCommand SearchArticleCommand { get; set; }
        public DelegateCommand DeleteArticleCommand { get; set; }

    }
}
