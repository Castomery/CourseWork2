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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Univetsity _univetsity;
        private People _people;
        private InfoLoader _infoLoader;

        private PersonCreatorPage _personCreatorPage;
        private EmployeeCreatorPage _employeeCreatorPage;
        private EmployeePage _employeePage;
        private PersonListPage _personListPage;
        public MainWindow()
        {
            InitializeComponent();
            _infoLoader = new InfoLoader("employees.txt", "people.txt");

            _univetsity = new Univetsity(_infoLoader.LoadEmployeesData());
            _people = new People(_infoLoader.LoadPeopleData());

                
            _employeePage = new EmployeePage(_univetsity, _people);
            _employeePage.OnDataChanged += SaveEmployeeData;
            _employeePage.OnDataChanged += SavePeopleData;
            _personListPage = new PersonListPage(_people);
            _personListPage.OnDeleteClicked += SavePeopleData;
            _personListPage.OnAddEmployee += GoToCreateEmployeePage;
        }

        private void SaveEmployeeData()
        {
            _infoLoader.SaveEmployeesData(_univetsity.Employees);
        }

        private void SavePeopleData()
        {
            _infoLoader.SavePeopleData(_people.PersonList);
        }

        private void GoToCreateEmployeePage(Person person)
        {
            _employeeCreatorPage = new EmployeeCreatorPage(_univetsity,person);
            _employeeCreatorPage.OnSaveClickedEvent += SaveEmployeeData;
            _employeeCreatorPage.OnSaveClickedEvent += SavePeopleData;
            _employeeCreatorPage.PersonInfo.Text = person.ToString();
            frame.Navigate(_employeeCreatorPage);
        }

        private void ChangeEmployeeInfo(Employee employee)
        {
            _employeeCreatorPage = new EmployeeCreatorPage(_univetsity, employee.PersonInfo);
            _employeeCreatorPage.OnSaveClickedEvent += SaveEmployeeData;
            _employeeCreatorPage.OnSaveClickedEvent += SavePeopleData;
            _employeeCreatorPage.PersonInfo.Text = employee.PersonInfo.ToString();
            _employeeCreatorPage.comboBoxPositions.Text = employee.GetType().Name;
            _employeeCreatorPage.salaryField.Text = employee.Salary.ToString();
            if (employee is Teacher)
            {
                _employeeCreatorPage.comboBoxWorkerType.SelectedIndex = (int)((Teacher)employee).TeacherType;
            }
            else if (employee is EngineeringEmployee)
            {
                _employeeCreatorPage.comboBoxWorkerType.SelectedIndex = (int)((EngineeringEmployee)employee).EnginerEmployeeType;
            }
            else if (employee is TechnicalEmployee)
            {
                _employeeCreatorPage.comboBoxWorkerType.SelectedIndex = (int)((TechnicalEmployee)employee).TechnicalEmployeeType;
            }
            frame.Navigate(_employeeCreatorPage);
        }

        private void CreatePerson_Click(object sender, RoutedEventArgs e)
        {
            _personCreatorPage = new PersonCreatorPage(_people);
            _personCreatorPage.OnSaveClickedEvent += SavePeopleData;
            frame.Navigate(_personCreatorPage);
        }

        private void EmployeePage_Click(object sender, RoutedEventArgs e)
        {
            _employeePage.UpdateData(_univetsity, _people);
            _employeePage.OnChangeEmployee += ChangeEmployeeInfo;
            frame.Navigate(_employeePage);
        }

        private void PersonList_Click(object sender, RoutedEventArgs e)
        {
            _personListPage.UpdateData(_people);
            
            frame.Navigate(_personListPage);
        }
    }
}
