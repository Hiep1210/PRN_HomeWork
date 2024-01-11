using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_database.Models;

namespace WPF_database.Logic
{
    class EmployeeService
    {
        private static EmployeeService employee;
        private EmployeeService() { }

        public static EmployeeService getInstance()
        {
            if(employee == null)
            {
                employee = new EmployeeService();
            }
            return employee; 
        }
        public List<Employee> GetEmployee(int empId = 0)
        {
            using(var context = new NorthwindContext())
            {
                if(empId == 0) return context.Employees.ToList();
                else return context.Employees.Where(e =>  e.EmployeeId == empId).ToList();
            }
        }
    }
}
