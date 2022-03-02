using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManagerCustomer
    {

        public static List<Customer> GetCustomer()
        {
            using (var context = new WarehouseContext())
            {
                var sqlvalues = context.Customers.Select(x => x);

                List<Customer> customerList = new List<Customer>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {

                        customerList.Add(item);
                    }
                }

                return customerList;
            }
        }



        public static Customer GetFirstCustomer(int id)
        {
            using (var context = new WarehouseContext())
            {
                return context.Customers.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static Customer GetFirstCustomer(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Customers.Where(x => x.FirstName.Contains(name) ||x.LastName.Contains(name)).FirstOrDefault();
            }
        }

        public static List<Customer> GetAllCustomer()
        {
            using (var context = new WarehouseContext())
            {
                return context.Customers.ToList();
            }
        }
        public static List<Customer> GetAllCustomer(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Customers.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name)).ToList();
            }
        }


        public int AddCustomer(string firstName, string lastName, string street, string zip, string city, string mail, string url, string password)
        {
            using (var context = new WarehouseContext())
            {

                var customer = new Customer()
                {
                FirstName = firstName,
                LastName = lastName,
                Street = street,
                Zip = zip,
                City = city,
                Mail = mail,
                Url = url,
                Password = password
            };


                context.Customers.Add(customer);
                context.SaveChanges();

                return customer.Id;
            }
        }

        public int AddCusomer(string firstName, string lastname)
        {
            return AddCustomer(firstName, lastname, "", "", "", "", "", "");
        }

        public bool EditCustomer(Customer customerChanges)
        {
            using (var context = new WarehouseContext())
            {
                var customer = context.Customers.Where(x => x.Id == customerChanges.Id).FirstOrDefault();

                customer.FirstName = customerChanges.FirstName;
                customer.LastName = customerChanges.LastName;
                customer.Street = customerChanges.Street;
                customer.Zip = customerChanges.Zip;
                customer.City = customerChanges.City;
                customer.Mail = customerChanges.Mail;
                customer.Url = customerChanges.Url;
                customer.Password = customerChanges.Password;

                int count = context.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteCustomer(Customer customerToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var customer = context.Customers.Where(x => x.Id == customerToDelete.Id).FirstOrDefault();

                context.Customers.Remove(customer);

                int count = context.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


   
    }
}

