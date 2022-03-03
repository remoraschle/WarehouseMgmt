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

                if (SelectedArticle != null)
                {
                    bool save = SelectedArticle.EditArticle(NewArticle);

                    NewArticle = new ArticleBLL
                    {
                        Id = NewArticle.Id,
                        Name = NewArticle.Name,
                        Price = NewArticle.Price,
                        ArticleGroupId = NewArticle.ArticleGroupId,
                        ArticleGroupName = NewArticle.ArticleGroupName,
                        ArticleGroup = NewArticle.ArticleGroup
                    };


                    //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in ArticleBLL on each Object
                    //therefore we just reload the whole List :-D

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


                    //Reselect after reloading the list
                    SelectedArticle = NewArticle;

                }
            });

            this.SearchArticleCommand = new DelegateCommand((o) =>
                {
                    //Will be called on button click

                    ArticleBLL art = new ArticleBLL();

                    
                    var list = art.GetArticles(NewArticle.SearchArticleNumber, NewArticle.SearchArticleName);

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

            this.SelectArticleGroupCommand = new DelegateCommand((o) =>
            {
                //Will be called on button click
                if (NewArticle != null && NewArticle.Id != 0)
                {
                    ArticleGroupWindow articleGroupWindow = new ArticleGroupWindow(NewArticle);
                    articleGroupWindow.ShowDialog();

                    NewArticle = new ArticleBLL
                    {
                        Id = NewArticle.Id,
                        Name = NewArticle.Name,
                        Price = NewArticle.Price,
                        ArticleGroupId = NewArticle.ArticleGroupId,
                        ArticleGroupName = NewArticle.ArticleGroupName,
                        ArticleGroup = NewArticle.ArticleGroup
                    };
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
                            ArticleGroupName = selectedArticle.ArticleGroupName,
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
        public DelegateCommand SelectArticleGroupCommand { get; set; }

    }
}
