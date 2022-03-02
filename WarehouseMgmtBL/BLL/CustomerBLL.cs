using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtBL
{
    public class CustomerBLL : Customer
    {
        public string CusomerGroupName { get; set; }
        public int? SearchCustomerNumber { get; set; }
        public string SearchCustomerName { get; set; }



        /// <summary>
        /// returns all articles
        /// </summary>
        public List<CustomerBLL> GetCustomer(int? id, string name)
        {
            List<Customer> customer = new List<Customer>();

            if (id != null && name == null)
            {
                Customer firstCustomer = EntityManager.GetFirstCustomer((int)id);
                if (firstCustomer != null)
                {
                    customer.Add(firstCustomer);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (name != null)
                {
                    if (name.Trim() == "")
                    {
                        customer = EntityManager.GetAllCustomer();
                    }
                    else
                    {
                        customer = EntityManager.GetAllCustomer(name);
                    }
                }
                else
                {
                    customer = EntityManager.GetAllCustomer();
                }
            }



            List<CustomerBLL> list = new List<CustomerBLL>();

            foreach (var v in customer)
            {
                CustomerBLL customerBLL = new CustomerBLL();
                customerBLL.Id = v.Id;
                customerBLL.FirstName = v.FirstName;
                customerBLL.LastName = v.LastName;
                customerBLL.Street = v.Street;
                customerBLL.Zip = v.Zip;
                customerBLL.City = v.City;
                customerBLL.Mail = v.Mail;
                customerBLL.Url = v.Url;
                customerBLL.Password = v.Password;

                list.Add(customerBLL);
            }

            return list;

        }



        /// <summary>
        /// returns the customer with the specifed article id
        /// </summary>
        /// <param name="id"></param>
        public CustomerBLL GetCustomerByCustomerID(int id)
        {
            return (CustomerBLL)EntityManager.GetFirstCustomer(id);
        }





        /// <summary>
        /// inserts a new customer into the databse using the values passed-in; returns the Customer id of the newly inserted record
        /// </summary>
        public int AddCustomer(string firstName, string lastName, string street, string zip, string city, string mail, string url, string password)
        {
            EntityManager entity = new EntityManager();
            return entity.AddCustomer(firstName, lastName,street, zip, city, mail, url , password);
        }
        public int AddCustomer(string firstName, string lastName)
        {
            return AddCustomer(firstName, lastName, "", "", "", "", "", "");
        }



        /// <summary>
        /// Edits a Customer
        /// </summary>
        public bool EditCustomer(CustomerBLL customer)
        {
            EntityManager entity = new EntityManager();
            return entity.EditCustomer(customer);
        }


        /// <summary>
        /// inserts a new customer into the databse using the values passed-in; returns the customer id of the newly inserted record
        /// </summary>
        public bool DeleteCustomer(CustomerBLL customer)
        {
            EntityManager entity = new EntityManager();
            return entity.DeleteCustomer(customer);
        }
    }
}
