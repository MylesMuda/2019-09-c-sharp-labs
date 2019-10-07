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

namespace lab_20_rabbit_database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;

        static Rabbit rabbit = new Rabbit();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        public void Initialise()
        {

            //make textboxes read-only
            TextBoxName.IsReadOnly = true;
            TextBoxAge.IsReadOnly = true;

            ButtonEdit.IsEnabled = false;
            ButtonDel.IsEnabled = false;

            //using: automatic cleanup (c# does not know inherently when we are done. This block helps let it know we're done, clean all memory)
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }
            //Fancy lambda to a) add loop b) each loop, add item to listbox on screen
            //get the list of rabbits. For each rabbit in the list of rabbits, do the following

            //rabbits.ForEach(rabbit => listBoxRabbits.Items.Add(rabbit));

            //foreach (var rabbit in rabbits){...listBoxRabbits.Items.Add....}

            //BINDING METHOD : Bind listbox to the database (better)
            listBoxRabbits.ItemsSource = rabbits;
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxRabbits.SelectedItem != null)
            {
                //Whenever we select an item in the list, cast it from type object to type RABBIT. Place it in the global 'rabbit' variable.
                rabbit = (Rabbit)listBoxRabbits.SelectedItem;
                //MessageBox.Show(rabbit.Name);

                TextBoxName.Text = rabbit.Name;
                TextBoxAge.Text = rabbit.Age.ToString();

                //enable edit and delete
                ButtonEdit.IsEnabled = true;
                ButtonDel.IsEnabled = true;
            }     

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hey, we're adding homie");
            if (ButtonAdd.Content.Equals("Add"))
            {
                ButtonAdd.Content = "Save";
                ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1D3A"));
                TextBoxName.Text = "";
                TextBoxAge.Text = "";
                TextBoxName.Background = (SolidColorBrush)Brushes.White;
                TextBoxAge.Background = (SolidColorBrush)Brushes.White;

                TextBoxName.IsReadOnly = false;
                TextBoxAge.IsReadOnly = false;

                ButtonEdit.IsEnabled = false;
                ButtonDel.IsEnabled = false;

                TextBoxName.Focus();
            }
            else
            {
                ButtonAdd.Content = "Add";
                ButtonAdd.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8C3E3"));
                //Clear out boxes, set to white
                TextBoxName.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD6E5"));
                TextBoxAge.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFD6E5"));
                TextBoxName.IsReadOnly = true;
                TextBoxAge.IsReadOnly = true;

                if(TextBoxName.Text.Length > 0 && TextBoxAge.Text.Length > 0)
                {
                    //get age
                    if(int.TryParse(TextBoxAge.Text, out int age))
                    {
                        var RabbitToAdd = new Rabbit()
                        {
                            Name = TextBoxName.Text,
                            Age = age
                        };
                        
                        using (var db = new RabbitDbEntities())
                        {
                            db.Rabbits.Add(RabbitToAdd);
                            db.SaveChanges();
                            rabbits = db.Rabbits.ToList();
                            listBoxRabbits.ItemsSource = rabbits;
                        }

                    }    
                }
            }

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonEdit.Content.Equals("Edit"))
            {
               // Color color = (Color)ColorConverter.ConvertFromString("#FF1D3A");
                ButtonEdit.Content = "Save";
                ButtonEdit.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1D3A"));
                TextBoxAge.IsReadOnly = false;
                TextBoxName.IsReadOnly = false;
                ButtonAdd.IsEnabled = false;

                TextBoxName.Focus();
                TextBoxName.SelectAll();
            }
            else //Save mode
            {
                ButtonEdit.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8C3E3"));
                ButtonEdit.Content = "Edit";
                TextBoxAge.IsReadOnly = true;
                TextBoxName.IsReadOnly = true;

                if(TextBoxAge.Text.Length > 0 && TextBoxName.Text.Length > 0)
                {
                    //must have a rabbit selected
                    if (rabbit != null)
                    {
                        rabbit.Name = TextBoxName.Text;
                        if(int.TryParse(TextBoxAge.Text, out int age))
                        {
                            rabbit.Age = age;
                        }

                        //Read Rabbit from database by the ID
                        using (var db = new RabbitDbEntities())
                        {
                            //Read Rabbit from database by the ID
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitId);
                            //UPDATE rabbit, save it back to the database
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            db.SaveChanges();
                            //CLEAR listbox - Remove binding, Clear it out
                            //rabbit = null;
                            //listBoxRabbits.ItemsSource = null;
                            //listBoxRabbits.Items.Clear();
                            //REPOPULATE - get rabbits, bind
                            rabbits = db.Rabbits.ToList();
                            listBoxRabbits.ItemsSource = rabbits;
                        }

                    }
                    ButtonAdd.IsEnabled = true;
                }
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if(ButtonDel.Content.Equals("Delete"))
            {
                ButtonDel.Content = "Confirm Delete";

                ButtonAdd.IsEnabled = false;
                ButtonEdit.IsEnabled = false;
            }
            else
            {
                if(rabbit != null)
                {
                    using(var db = new RabbitDbEntities())
                    {
                        var rabbitToDelete = db.Rabbits.Find(rabbit.RabbitId);
                        db.Rabbits.Remove(rabbitToDelete);
                        db.SaveChanges();

                        rabbits = db.Rabbits.ToList();
                        listBoxRabbits.ItemsSource = rabbits;
                        TextBoxAge.Text = "";
                        TextBoxName.Text = "";

                        ButtonAdd.IsEnabled = true;
                        ButtonEdit.IsEnabled = true;
                    }
                }

                ButtonDel.Content = "Delete";
            }

        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
