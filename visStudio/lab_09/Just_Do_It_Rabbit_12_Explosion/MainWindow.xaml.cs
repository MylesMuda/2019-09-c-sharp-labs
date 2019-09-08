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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string RName = Name.Text;
            string RAge = Age.Text;
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
