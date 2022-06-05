using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class Administrator : Employee
    {

        private const double BONUS_KOEF_FOR_ADMINISTRATOR = 0.5;

        private Person _personInfo;
        private double _salary;
        public Administrator(Person person, double salary):base(person, salary) 
        {
        }

        public override void GetBonuses(double bonusPercent)
        {
            _salary += _salary * BONUS_KOEF_FOR_ADMINISTRATOR * (bonusPercent / 100);
        }

        public override string GetEmployeeType()
        {
            return String.Empty;
        }

        public override string GetInfo()
        {
            return $"Administrator \n{_personInfo}\nSalary: {_salary}";
        }

        public override Person PersonInfo { get => _personInfo; protected set => _personInfo = value; }
        public override double Salary { get => _salary; protected set => _salary = value; }
    }
}
