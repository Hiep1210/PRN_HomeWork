using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_database.Models;

namespace WPF_database.Logic
{
    class OrderService
    {
        public List<Order> getOrder(int id =0)
        {
            using(var context = new NorthwindContext())
            {
                if(id == 0) return context.Orders.ToList();
                else return context.Orders.Include(x => x.Employee).Where(o => o.EmployeeId == id).ToList();
            }
        }

        public List<Order> getOrderFromDate(DateTime orderDate)
        {
            using (var context = new NorthwindContext())
            {
                return context.Orders.Include(x => x.Employee).Where(o => o.OrderDate >= orderDate).ToList();
            }
        }
        
        public List<Order> getOrderToDate(DateTime orderDate)
        {
            using (var context = new NorthwindContext())
            {
                return context.Orders.Include(x => x.Employee).Where(o => o.OrderDate <= orderDate).ToList();
            }
        }

        public List<Order> sortByOrderId(List<Order> orders)
        {
            using( var context = new NorthwindContext())
            {
                return orders.OrderBy(x => x.OrderId).ToList();
            }
        }
        public List<Order> sortByOrderDate(List<Order> orders)
        {
            using( var context = new NorthwindContext())
            {
                return orders.OrderByDescending(x => x.OrderDate).ToList();
            }
        }
    }
}
