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
using System.Collections.ObjectModel;

namespace Kollection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Изменяем List<Person> на ObservableCollection<Person>
        private ObservableCollection<Person> persons;

        public MainWindow()
        {
            InitializeComponent();
            persons = new ObservableCollection<Person>();
            LoadPersons();
            UpdateListAndDataGrid();
        }
        //Добавление 
        private void LoadPersons()
        {
            persons.Add(new Person { Name = "Tom", Age = 18 });
            persons.Add(new Person { Name = "Bob", Age = 21 });
            persons.Add(new Person { Name = "Sam", Age = 23 });
            persons.Add(new Person { Name = "Diana", Age = 28 });
            persons.Add(new Person { Name = "Alice", Age = 40 });

            UpdateListAndDataGrid();
        }
        //Обновление 
        private void UpdateListAndDataGrid()
        {
            personListBox.ItemsSource = null;
            personListBox.ItemsSource = persons;
            personDataGrid.ItemsSource = null;
            personDataGrid.ItemsSource = persons;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            
            if (int.TryParse(ageTextBox.Text, out int age) && !string.IsNullOrWhiteSpace(name))
            {
               persons.Add(new Person { Name = name, Age = age });
               UpdateListAndDataGrid();
               statusLabel.Content = "Пользователь успешно добавлен!";
               nameTextBox.Clear();
               ageTextBox.Clear();
            }
            else
            {
                statusLabel.Content = "Введите имя и возраст";
            }
            
        }
            

    }
}
