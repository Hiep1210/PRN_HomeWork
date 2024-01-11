using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_database.Models;

namespace WPF_database.Logic
{
    class Categoryservice
    {
        public List<Category> GetCategories(int categoryId = 0)
        {
            using (var context = new NorthwindContext())
            {
                if (categoryId == 0) return context.Categories.ToList();
                else return context.Categories.Where(p => p.CategoryId == categoryId).ToList();
            }
        }
    }
}
