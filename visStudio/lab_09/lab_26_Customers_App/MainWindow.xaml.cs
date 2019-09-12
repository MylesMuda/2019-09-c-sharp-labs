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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_26_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Collapsed;
            back.IsEnabled = false;

            using (var db = new NorthwindEntities())
            {
                ListBoxCustomers.ItemsSource = db.Customers.ToList();
                //ListBoxCustomers.DisplayMemberPath = "ContactName";
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            if (StackPanel02.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Visible;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Collapsed;
                back.IsEnabled = false;
                forward.IsEnabled = true;
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Visible;
                StackPanel03.Visibility = Visibility.Collapsed;
                forward.IsEnabled = true;
            }
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Visible;
                StackPanel03.Visibility = Visibility.Collapsed;
                back.IsEnabled = true;
                
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Visible;
                forward.IsEnabled = false;
            }
        }

        private void CustomerSearch_KeyUp(object sender, KeyEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                ListBoxCustomers.ItemsSource = db.Customers.Where(c=> c.ContactName.Contains(CustomerSearch.Text)).ToList();
                //ListBoxCustomers.DisplayMemberPath = "ContactName";
            }
        }

        

        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
