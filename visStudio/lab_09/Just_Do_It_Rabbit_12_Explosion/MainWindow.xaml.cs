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
using System.Threading;

namespace Just_Do_It_Rabbit_12_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //rabbet.Visibility = Visibility.Hidden;
            rabbet.Opacity = 0d;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string RName = Name.Text;
            string RAge = Age.Text;
            Tb1.Text = RName;
            Tb2.Text = RAge;
            //rabbet.Visibility = Visibility.Visible;
            RabbitAppear();
        }

        public void RabbitAppear()
        {
            //rabbet.Visibility = Visibility.Visible;
            //System.Threading.Thread.Sleep(2000);
            //rabbet.Visibility = Visibility.Hidden;
            rabbet.Opacity = 100d;
            for(int i = 100; i >= 0; i--)
            {
                rabbet.Opacity = i;
                //Thread.Sleep();
            }
        }

        //public void PopulateListBox()
        //{
        //    using (var db = new RabbitDbEntities())
        //    {
        //        List<Rabbit> rabbits = db.Rabbits.ToList();
        //        foreach (Rabbit rb in rabbits)
        //        {
        //            listBox.Items.Add(rb.Name);
        //        }
        //    }
        //}
    }
}
