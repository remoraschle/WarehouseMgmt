using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManager
    {

        #region Article
        public static List<Article> GetArticle()
        {
            using (var context = new WarehouseContext())
            {
                var sqlvalues = context.Articles.Select(x=>x);

                List<Article> articleList = new List<Article>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {
                        using (var context2 = new WarehouseContext())
                        {
                            item.ArticleGroup = context2.ArticleGroups.Where(x => x.Id == item.ArticleGroupId).FirstOrDefault(); //todooooo
                        }
                            
                        articleList.Add(item);
                    }
                }

                return articleList;
            }
        }

        public static List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public static Article GetFirstArticle(int id)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static Article GetFirstArticle(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Name == name).FirstOrDefault();
            }
        }

        public static List<Article> GetAllArticle()
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.ToList();
            }
        }
        public static List<Article> GetAllArticle(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Name.Contains(name)).ToList();
            }
        }


        public int AddArticle(string name, decimal price)
        {
            using (var context = new WarehouseContext())
            {
                var articlegroup1 = new ArticleGroup()
                {
                    Name = "ArticleGroup1"
                };

                var article1 = new Article()
                {
                    Name = name,
                    Price = price,
                    ArticleGroup = articlegroup1
                };


                context.Articles.Add(article1);
                context.SaveChanges();

                return article1.Id;
            }
        }

        public bool EditArticle(Article articleChanges)
        {
            using (var context = new WarehouseContext())
            {
                var article = context.Articles.Where(x => x.Id == articleChanges.Id).FirstOrDefault();

                article.Name = articleChanges.Name;
                article.Price = articleChanges.Price;
                //article.ArticleGroup = articleChanges.ArticleGroup;
                //article.ArticleGroupId = articleChanges.ArticleGroupId;

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

        public bool DeleteArticle(Article articleToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var article = context.Articles.Where(x => x.Id == articleToDelete.Id).FirstOrDefault();

                context.Articles.Remove(article);

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

        #endregion


        #region Customer
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

        #endregion
    }
}

