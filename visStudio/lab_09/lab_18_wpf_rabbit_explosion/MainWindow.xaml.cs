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
using System.Windows.Threading;

namespace lab_18_wpf_rabbit_explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            initialise();
        }

        void initialise()
        {
            timer.Start();
            Button01.Content = "Click Here!";
            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += changeColour;
        }

        static int counter = 0;
        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            
            counter++;
            Button01.Content = $"Clicked {counter} times!";
            
        }

        void changeColour(object sender, EventArgs e)
        {
            var rand = new Random();

            var x = rand.Next(255);
            var y = rand.Next(255);
            var z = rand.Next(255);

            //random colour generator
            Label01.Background = new SolidColorBrush(Color.FromRgb((byte)x, (byte)y, (byte)z));
        }
    }
}
