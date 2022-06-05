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
    /// Логика взаимодействия для CreateWorkerPage.xaml
    /// </summary>
    public partial class EmployeeCreatorPage : Page
    {
        public event Action OnSaveClickedEvent;
        private Univetsity _univetsity;
        private Person _currentPerson;
        public EmployeeCreatorPage(Univetsity univetsity, Person person)
        {
            InitializeComponent();
            _univetsity = univetsity;
            _currentPerson = person;
        }

        private void SaveWorker_Click(object sender, RoutedEventArgs e)
        {
            _currentPerson.IsEmployee = true;
            switch (comboBoxPositions.SelectedIndex)
            {
                case 0:
                    _univetsity.AddEmployee(new Administrator(_currentPerson, double.Parse(salaryField.Text)));
                    break;
                case 1:
                    _univetsity.AddEmployee(new Teacher(_currentPerson, double.Parse(salaryField.Text), (TeacherType)comboBoxWorkerType.SelectedIndex));
                    break;
                case 2:
                    _univetsity.AddEmployee(new EngineeringEmployee(_currentPerson, double.Parse(salaryField.Text), (EngineeringEmployeeType)comboBoxWorkerType.SelectedIndex));
                    break;
                case 3:
                    _univetsity.AddEmployee(new TechnicalEmployee(_currentPerson, double.Parse(salaryField.Text), (TechnicalEmployeeType)comboBoxWorkerType.SelectedIndex));
                    break;
            }
            OnSaveClickedEvent?.Invoke();
            MessageBox.Show("Employee was added!");
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (comboBoxPositions.SelectedIndex)
            {
                case 0:
                    labelWorkerType.Visibility = Visibility.Hidden;
                    comboBoxWorkerType.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    labelWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.ItemsSource = Enum.GetValues(typeof(TeacherType)).Cast<TeacherType>();
                    break;
                case 2:

                    labelWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.ItemsSource = Enum.GetValues(typeof(EngineeringEmployeeType)).Cast<EngineeringEmployeeType>();
                    break;
                case 3:
                    labelWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.Visibility = Visibility.Visible;
                    comboBoxWorkerType.ItemsSource = Enum.GetValues(typeof(TechnicalEmployeeType)).Cast<TechnicalEmployeeType>();
                    break;
                default:
                    break;
            }
        }
    }
}
