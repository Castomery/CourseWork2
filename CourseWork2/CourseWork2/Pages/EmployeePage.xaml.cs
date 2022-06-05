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
    /// Логика взаимодействия для WorkersPage.xaml
    /// </summary>
    /// 
    public delegate List<FilteredEmployeeInfo> GetFilteredEmployee();
    public partial class EmployeePage : Page
    {
        private Univetsity _university;
        private People _people;
        public event Action<Employee> OnChangeEmployee;
        public event Action OnDataChanged;
        private GetFilteredEmployee[] filteredEmployee;
        public EmployeePage(Univetsity univetsity, People people)
        {
            InitializeComponent();
            _university = univetsity;
            _people = people;
            filteredEmployee = new GetFilteredEmployee[5] {
                                                           _university.GetAllEmployee, 
                                                           _university.GetPensioners, 
                                                           _university.GetPreRetirements,
                                                           _university.GetChildlesses,
                                                           _university.GetEmployeeWithManyChildren
                                                          };

            EmployeeList.ItemsSource = filteredEmployee[0]();
            EmployeeType.SelectedIndex = 0;
        }

        public void UpdateData(Univetsity university, People people)
        {
            _university = university;
            _people = people;
            EmployeeList.ItemsSource = filteredEmployee[EmployeeType.SelectedIndex]();
        }

        private void ChangePosition_Click(object sender, RoutedEventArgs e)
        {
            OnChangeEmployee?.Invoke(_university.Employees[EmployeeList.SelectedIndex]);
        }

        private void EmployeeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeList.ItemsSource = filteredEmployee[EmployeeType.SelectedIndex]();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = _people.GetPersonById(((FilteredEmployeeInfo)EmployeeList.SelectedItem).PersonInfo.Id);
            selectedPerson.IsEmployee = false;
            _university.RemoveEmployee(selectedPerson.Id);
            EmployeeList.ItemsSource = filteredEmployee[EmployeeType.SelectedIndex]();
            OnDataChanged?.Invoke();
        }

        private void GetBonus_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = _university.GetEmployeeById(((FilteredEmployeeInfo)EmployeeList.SelectedItem).PersonInfo.Id);
            Window1 window1 = new Window1(selectedEmployee);
            window1.Show();
            window1.OnDataChanged += UpdateSalaryData;    
        }

        private void UpdateSalaryData()
        {
            EmployeeList.ItemsSource = filteredEmployee[EmployeeType.SelectedIndex]();
            OnDataChanged?.Invoke();
        }

    }
}
