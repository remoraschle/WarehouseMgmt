using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtBL;
using WarehouseMgmtBL.BLL;

namespace WarehouseMgmtGUI
{
    public class BillViewWindowViewModel : NotifyableBaseObject
    {
        public BillViewWindowViewModel()
        {
            //this.AddBillViewGroupCommand = new DelegateCommand((o) => AddBillViewGroup());

            //this.SaveBillViewGroupCommand = new DelegateCommand((o) => SaveBillViewGroup());

            this.SearchBillViewGroupCommand = new DelegateCommand((o) => SearchBillViewGroup());

            //this.DeleteBillViewGroupCommand = new DelegateCommand((o) => DeleteBillViewGroup());

        }

    

        ViewsBLL newviewsBLL = new ViewsBLL();

        public ViewsBLL NewBillView
        {
            get => newviewsBLL;
            set
            {
                if (newviewsBLL != value)
                {
                    newviewsBLL = value;
                    this.RaisePropertyChanged();
                }
            }
        }


        

        private ObservableCollection<ViewsBLL> billViewGroups = new ObservableCollection<ViewsBLL>();

        public ObservableCollection<ViewsBLL> BillViewGroups
        {
            get => billViewGroups;
            set
            {
                if (billViewGroups != value)
                {
                    billViewGroups = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        //public DelegateCommand AddBillViewGroupCommand { get; set; }
        //public DelegateCommand SaveBillViewGroupCommand { get; set; }
        public DelegateCommand SearchBillViewGroupCommand { get; set; }
        //public DelegateCommand DeleteBillViewGroupCommand { get; set; }
        //public DelegateCommand ChangeBillViewGroupInBillViewCommand { get; set; }
        

        private void SearchBillViewGroup()
        {
           
            var list = ViewsBLL.GetBillView();

            this.BillViewGroups = new ObservableCollection<ViewsBLL>();

            if (list != null)
            {
                foreach (ViewsBLL item in list)
                {
                    this.BillViewGroups.Add(item);
                }
            }

        }

        //private void AddBillViewGroup()
        //{
        //    ViewsBLL art = new ViewsBLL();

        //    int id = art.AddBillViewGroup(newBillViewGroup.Name, newBillViewGroup.BillViewGroupParentId);
        //    newBillViewGroup.Id = id;
        //    this.BillViewGroups.Add(newBillViewGroup);
        //    NewBillViewGroup = new ViewsBLL();
        //}

        //private void SaveBillViewGroup()
        //{
        //    if (selectedBillViewGroup != null)
        //    {
        //        bool save = selectedBillViewGroup.EditBillViewGroup(NewBillViewGroup);

        //        //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in ViewsBLL on each Object
        //        //therefore we just reload the whole List :-D
        //        SearchBillViewGroup();

        //        //Reselect after reloading
        //        SelectedBillViewGroup = NewBillViewGroup;
        //    }
        //}

        //private void DeleteBillViewGroup()
        //{
        //    if (selectedBillViewGroup != null)
        //    {
        //        bool save = selectedBillViewGroup.DeleteBillViewGroup(newBillViewGroup);

        //        BillViewGroups.Remove(selectedBillViewGroup);


        //        //Data in the ListBox are not updating, because there shoud also be a RaisePropertyChanged in ViewsBLL on each Object --> ParentID
        //        //therefore we just reload the whole List :-D

        //        SearchBillViewGroup();

        //        NewBillViewGroup = new ViewsBLL();
        //    }
        //}
    }
}
