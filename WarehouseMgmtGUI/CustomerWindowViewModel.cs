﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WarehouseMgmtGUI
{
    class CustomerWindowViewModel :INotifyPropertyChanged
    {
        public CustomerWindowViewModel()
        {
            CustomerNumber = 1;
            CustomerName = "Name";
            CustomerStreet = "Strasse";
            CustomerPLZ = "1111";
            CustomerLocation = "SG";
            CustomerMail = "Max.Mustermann@gmail.com";
            CustomerWebsite = "google.ch";
            CustomerPW = "1234";

            this.SaveCommand = new DelegateCommand((o) => SaveCustomer());
        }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerPLZ { get; set; }
        public string CustomerLocation { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerWebsite { get; set; }
        public string CustomerPW { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

      

        string saveTest;
        public string SaveTest
        {
            get => saveTest;
            set
            {
                if (saveTest != value)
                {
                    saveTest = value;
                    this.RaisePropertyChanged();
                    this.SaveCommand.RaiseCanExecuteChanged(); 
                }
            }
        }

        private void SaveCustomer()
        {
            this.SaveTest = "gespeichert"; //test
        }
    }
}