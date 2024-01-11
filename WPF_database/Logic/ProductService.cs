using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_database.Models;

namespace WPF_database.Logic
{
    internal class ProductServices
    {
        public ProductServices() { }
        public List<Product> GetProducts(int categoryId = 0) { 
            using(var context = new NorthwindContext())
            {
                if(categoryId == 0) return context.Products.ToList();
                else return context.Products.Where(p => p.CategoryId == categoryId).ToList();
            }
        }

    }
}
