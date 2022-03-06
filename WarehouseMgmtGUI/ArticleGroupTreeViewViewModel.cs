using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;

namespace WarehouseMgmtGUI
{
    public class ArticleGroupTreeViewViewModel : NotifyableBaseObject
    {
        public ArticleGroupTreeViewViewModel()
        {


            this.SearchArticleGroupCommand = new DelegateCommand((o) => SearchArticleGroupTree());



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


        public DelegateCommand SearchArticleGroupCommand { get; set; }

        

        private void SearchArticleGroupTree()
        {
            var list = ArticleGroupBLL.GetArticleGroupTree();


            this.ArticleGroups = new ObservableCollection<ArticleGroupBLL>();

            if (list != null)
            {
                foreach (ArticleGroupBLL item in list)
                {
                    this.ArticleGroups.Add(item);
                }
            }
        }

    }
}
