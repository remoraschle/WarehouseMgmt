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
            this.SearchBillViewGroupCommand = new DelegateCommand((o) => SearchBillViewGroup());
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

        public DelegateCommand SearchBillViewGroupCommand { get; set; }


        private void SearchBillViewGroup()
        {
            var list = ViewsBLL.GetBillView(NewBillView.SearchCustomerId);

            this.BillViewGroups = new ObservableCollection<ViewsBLL>();

            if (list != null)
            {
                foreach (ViewsBLL item in list)
                {
                    this.BillViewGroups.Add(item);
                }
            }

        }

    }
}
