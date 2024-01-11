using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_database.Logic;
using WPF_database.Models;

namespace WPF_database
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        private EmployeeService employeeService;
        private OrderService orderService;
        private List<Order> listName;
        private List<Order> listDateFrom;
        private List<Order> listDateTo;
        private List<Order> filteredList;
        public OrderView()
        {
            InitializeComponent();
            //employeeService = new EmployeeService();
            orderService = new OrderService();
            cbEmp.ItemsSource = EmployeeService.getInstance().GetEmployee();

            listName = new List<Order>();
            listDateFrom = new List<Order>();
            listDateTo = new List<Order>();
            filteredList = new List<Order>();
        }

        private void ChangeEmpName(object sender, SelectionChangedEventArgs e)
        {
            try {
                int empId = ((Employee)cbEmp.SelectedItem).EmployeeId;
                //lbOrder.ItemsSource = filteredOrder.Intersect(orderService.getOrder(empId)).ToList();
                listName = orderService.getOrder(empId);
                if(listDateFrom.Count > 0) listName = listName.Intersect(listDateFrom).ToList();
                if(listDateTo.Count > 0) listName = listName.Intersect(listDateTo).ToList();
                filteredList = listName;
                lbOrder.ItemsSource = listName;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void ChangeDateFrom(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker datePicker = sender as DatePicker;
                DateTime orderDate = datePicker.SelectedDate.Value;
                listDateFrom = orderService.getOrderFromDate(orderDate);
                if (listName.Count > 0) listDateFrom = listDateFrom.Intersect(listName).ToList();
                if (listDateTo.Count > 0) listDateFrom = listDateFrom.Intersect(listDateTo).ToList();
                filteredList = listDateFrom;
                lbOrder.ItemsSource = listDateFrom;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void ChangeDateTo(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatePicker datePicker = sender as DatePicker;
                DateTime orderDate = datePicker.SelectedDate.Value;
                listDateTo = orderService.getOrderToDate(orderDate);
                if (listName.Count > 0) listDateTo = listDateTo.Intersect(listName).ToList();
                if (listDateFrom.Count > 0) listDateTo = listDateTo.Intersect(listDateFrom).ToList();
                filteredList = listDateTo;
                lbOrder.ItemsSource = listDateTo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SortByOrderId(object sender, RoutedEventArgs e)
        {
            lbOrder.ItemsSource = orderService.sortByOrderId(filteredList);
        }

        private void SortByOrderDate(object sender, RoutedEventArgs e)
        {
            lbOrder.ItemsSource = orderService.sortByOrderDate(filteredList);
        }
    }
}
