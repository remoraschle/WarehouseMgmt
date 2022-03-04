using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    public class ArticleGroupWindowViewModel : NotifyableBaseObject
    {
        public ArticleGroupWindowViewModel()
        {
            this.AddArticleGroupCommand = new DelegateCommand((o) => AddArticleGroup());

            this.SaveArticleGroupCommand = new DelegateCommand((o) => SaveArticleGroup());

            this.SearchArticleGroupCommand = new DelegateCommand((o) => SearchArticleGroup());

            this.DeleteArticleGroupCommand = new DelegateCommand((o) => DeleteArticleGroup());

        }

        public ArticleGroupWindowViewModel(ArticleBLL articleBLL)
        {
            if (articleBLL != null)
            {

                this.AddArticleGroupCommand = new DelegateCommand((o) => AddArticleGroup());

                this.SaveArticleGroupCommand = new DelegateCommand((o) => SaveArticleGroup());

                this.SearchArticleGroupCommand = new DelegateCommand((o) => SearchArticleGroup());

                this.DeleteArticleGroupCommand = new DelegateCommand((o) => DeleteArticleGroup());


                this.ChangeArticleGroupInArticleCommand = new DelegateCommand((o) =>
                {

                    articleBLL.ArticleGroup = NewArticleGroup;
                    articleBLL.ArticleGroupId = NewArticleGroup.Id;
                    articleBLL.ArticleGroupName = newArticleGroup.Name;

                });



                if (articleBLL != null)
                {
                    ArticleGroupBLL art = new ArticleGroupBLL();

                    var article = art.GetArticleGroups(articleBLL.ArticleGroupId, null).FirstOrDefault();
                    if (article != null)
                    {
                        NewArticleGroup = article;
                    }
                }
            }

        }

        ArticleGroupBLL newArticleGroup = new ArticleGroupBLL();

        public ArticleGroupBLL NewArticleGroup
        {
            get => newArticleGroup;
            set
            {
                if (newArticleGroup != value)
                {
                    newArticleGroup = value;
                    this.RaisePropertyChanged();
                }
            }
        }


        ArticleGroupBLL selectedArticleGroup = new ArticleGroupBLL();

        public ArticleGroupBLL SelectedArticleGroup
        {
            get => selectedArticleGroup;
            set
            {
                if (selectedArticleGroup != value)
                {
                    selectedArticleGroup = value;

                    if (selectedArticleGroup != null)
                    {
                        NewArticleGroup = new ArticleGroupBLL
                        {
                            Id = selectedArticleGroup.Id,
                            Name = selectedArticleGroup.Name,
                            ArticleGroupParentId = selectedArticleGroup.ArticleGroupParentId
                        };
                    }

                    this.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<ArticleGroupBLL> articleGroups = new ObservableCollection<ArticleGroupBLL>();

        public ObservableCollection<ArticleGroupBLL> ArticleGroups
        {
            get => articleGroups;
            set
            {
                if (articleGroups != value)
                {
                    articleGroups = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand AddArticleGroupCommand { get; set; }
        public DelegateCommand SaveArticleGroupCommand { get; set; }
        public DelegateCommand SearchArticleGroupCommand { get; set; }
        public DelegateCommand DeleteArticleGroupCommand { get; set; }
        public DelegateCommand ChangeArticleGroupInArticleCommand { get; set; }
        

        private void SearchArticleGroup()
        {
            ArticleGroupBLL art = new ArticleGroupBLL();

            var list = art.GetArticleGroups(newArticleGroup.SearchArticleGroupNumber, newArticleGroup.SearchArticleGroupName);

            this.ArticleGroups = new ObservableCollection<ArticleGroupBLL>();

            if (list != null)
            {
                foreach (ArticleGroupBLL item in list)
                {
                    this.ArticleGroups.Add(item);
                }
            }

        }

        private void AddArticleGroup()
        {
            ArticleGroupBLL art = new ArticleGroupBLL();

            int id = art.AddArticleGroup(newArticleGroup.Name, newArticleGroup.ArticleGroupParentId);
            newArticleGroup.Id = id;
            this.ArticleGroups.Add(newArticleGroup);
            NewArticleGroup = new ArticleGroupBLL();
        }

        private void SaveArticleGroup()
        {
            if (selectedArticleGroup != null)
            {
                bool save = selectedArticleGroup.EditArticleGroup(NewArticleGroup);

                //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in ArticleGroupBLL on each Object
                //therefore we just reload the whole List :-D
                SearchArticleGroup();

                //Reselect after reloading
                SelectedArticleGroup = NewArticleGroup;
            }
        }

        private void DeleteArticleGroup()
        {
            if (selectedArticleGroup != null)
            {
                bool save = selectedArticleGroup.DeleteArticleGroup(newArticleGroup);

                ArticleGroups.Remove(selectedArticleGroup);


                //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in ArticleGroupBLL on each Object --> ParentID
                //therefore we just reload the whole List :-D

                SearchArticleGroup();

                NewArticleGroup = new ArticleGroupBLL();
            }
        }
    }
}
