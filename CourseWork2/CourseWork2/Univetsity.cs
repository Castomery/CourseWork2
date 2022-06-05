using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class Univetsity
    {
        private readonly int _penionAge = 65;
        private readonly int _manyChildAmount = 3;

        public List<Employee> Employees { get; private set; }

        public Univetsity()
        {
            Employees = new List<Employee>();
        }

        public Univetsity(List<Employee> employees)
        {
            Employees = employees;
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
            {
                Employees.Remove(employee);
            }

            Employees.Add(employee);
        }

        public void RemoveEmployee(Guid id)
        {
            foreach (var item in Employees)
            {
                if (item.PersonInfo.Id == id)
                {
                    Employees.Remove(item);
                    break;
                }
            }
        }

        public Employee GetEmployeeById(Guid id)
        {
            foreach (var item in Employees)
            {
                if (item.PersonInfo.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<FilteredEmployeeInfo> GetAllEmployee()
        {
            List<FilteredEmployeeInfo> allEmployee = new List<FilteredEmployeeInfo>();

            foreach (var item in Employees)
            {
                FilteredEmployeeInfo employeeInfo = new FilteredEmployeeInfo(item.PersonInfo, item.Salary, item.GetType().Name, item.GetEmployeeType());
                allEmployee.Add(employeeInfo);
            }

            return allEmployee;
        }

        public List<FilteredEmployeeInfo> GetPensioners()
        {
            List<FilteredEmployeeInfo> pensioners = new List<FilteredEmployeeInfo>();

            foreach (var item in Employees)
            {
                
                if (item.PersonInfo.Age >= _penionAge)
                {
                    FilteredEmployeeInfo employeeInfo = new FilteredEmployeeInfo(item.PersonInfo, item.Salary, item.GetType().Name, item.GetEmployeeType());
                    pensioners.Add(employeeInfo);
                }
            }

            return pensioners;
        }

        public List<FilteredEmployeeInfo> GetPreRetirements()
        {
            List<FilteredEmployeeInfo> preRetirements = new List<FilteredEmployeeInfo>();

            foreach (var item in Employees)
            {

                if (item.PersonInfo.Age < _penionAge && item.PersonInfo.Age >= _penionAge - 2)
                {
                    FilteredEmployeeInfo employeeInfo = new FilteredEmployeeInfo(item.PersonInfo, item.Salary, item.GetType().Name, item.GetEmployeeType());
                    preRetirements.Add(employeeInfo);
                }
            }

            return preRetirements;
        }

        public List<FilteredEmployeeInfo> GetChildlesses()
        {
            List<FilteredEmployeeInfo> childlesses = new List<FilteredEmployeeInfo>();

            foreach (var item in Employees)
            {

                if (item.PersonInfo.KidsAmount == 0)
                {
                    FilteredEmployeeInfo employeeInfo = new FilteredEmployeeInfo(item.PersonInfo, item.Salary, item.GetType().Name, item.GetEmployeeType());
                    childlesses.Add(employeeInfo);
                }
            }

            return childlesses;
        }

        public List<FilteredEmployeeInfo> GetEmployeeWithManyChildren()
        {
            List<FilteredEmployeeInfo> employeeWithManyChildren = new List<FilteredEmployeeInfo>();

            foreach (var item in Employees)
            {

                if (item.PersonInfo.KidsAmount >= _manyChildAmount)
                {
                    FilteredEmployeeInfo employeeInfo = new FilteredEmployeeInfo(item.PersonInfo, item.Salary, item.GetType().Name, item.GetEmployeeType());
                    employeeWithManyChildren.Add(employeeInfo);
                }
            }

            return employeeWithManyChildren;
        }
    }
}
