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
using System.Windows.Shapes;

namespace CourseWork2
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public event Action OnDataChanged;
        private Employee _currentEmployee;
        public Window1(Employee employee)
        {
            InitializeComponent();
            _currentEmployee = employee;
            infoField.Text = _currentEmployee.GetInfo();
        }

        private void GetBonus_Click(object sender, RoutedEventArgs e)
        {
            _currentEmployee.GetBonuses(double.Parse(percentValue.Text));
            OnDataChanged?.Invoke();
            this.Close();
        }
    }
}
