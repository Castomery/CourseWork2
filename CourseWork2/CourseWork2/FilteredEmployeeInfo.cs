using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class FilteredEmployeeInfo
    {
        public Person PersonInfo { get; private set; }
        public double Salary { get; private set; }
        public string EmployeePosition { get; private set; }

        public string EmployeeType { get; private set; }

        public FilteredEmployeeInfo(Person person, double salary, string employeePosition, string employeeType)
        {
            PersonInfo = person;
            Salary = salary;
            EmployeePosition = employeePosition;
            EmployeeType = employeeType;
        }
    }
}
