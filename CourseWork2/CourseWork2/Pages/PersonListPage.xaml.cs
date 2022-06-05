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

namespace CourseWork2
{
    /// <summary>
    /// Логика взаимодействия для PersonListPage.xaml
    /// </summary>
    public partial class PersonListPage : Page
    {
        public event Action<Person> OnAddEmployee;
        public event Action OnDeleteClicked;
        private People _people;
        public PersonListPage(People people)
        {
            InitializeComponent();
            _people = people;
            personList.ItemsSource = _people.PersonList;
        }

        public void UpdateData(People people)
        {
            _people = people;
            personList.ItemsSource = null;
            personList.ItemsSource = _people.PersonList;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (_people.PersonList[personList.SelectedIndex].IsEmployee)
            {
                return;
            }
            OnAddEmployee?.Invoke(_people.PersonList[personList.SelectedIndex]);
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = (Person)personList.SelectedItem;
            if (selectedPerson.IsEmployee)
            {
                return;
            }
            _people.RemovePerson(selectedPerson);
            personList.ItemsSource = null;
            personList.ItemsSource = _people.PersonList;
            OnDeleteClicked?.Invoke();
        }
    }
}
