using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public abstract class Employee : IEquatable<Employee>
    {
        public abstract Person PersonInfo { get; protected set; }
        public abstract double Salary { get; protected set; }

        public Employee(Person person, double salary)
        {
            if (salary < 0)
            {
                throw new Exception("Invalid salary data");
            }
            PersonInfo = person;
            Salary = salary;
        }

        public abstract void GetBonuses(double bonusPercent);

        public abstract string GetEmployeeType();

        public abstract string GetInfo();

        public bool Equals(Employee other)
        {
            return PersonInfo.Id.Equals(other.PersonInfo.Id);
        }
    }
}
