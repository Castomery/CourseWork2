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
    /// Логика взаимодействия для PersonCreatorPage.xaml
    /// </summary>
    public partial class PersonCreatorPage : Page
    {
        public event Action OnSaveClickedEvent;
        public People PeopleList { get; private set; } 
        
        public PersonCreatorPage(People people) 
        {
            InitializeComponent();
            PeopleList = people;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(textBoxName.Text, textBoxSurname.Text, int.Parse(textBoxAge.Text), int.Parse(textBoxKidsAmount.Text),false, Guid.NewGuid());
            PeopleList.AddPerson(person);
            Clear();
            OnSaveClickedEvent?.Invoke();
        }

        private void Clear()
        {
            textBoxName.Clear();
            textBoxSurname.Clear();
            textBoxAge.Clear();
            textBoxKidsAmount.Clear();
        }
    }
}
