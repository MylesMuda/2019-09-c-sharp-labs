using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin_hello_world
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

  

    public partial class MainPage : ContentPage
    {

        List<string> myList = new List<string>();
        public MainPage()
        {
            InitializeComponent();
        }

        private void Hello_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "G'DAY MATE", "OK");
            
            for (int i = 0; i < 10; i++)
            {
                myList.Add("Myles"); 
            }
        }
        
        
    }
}
