using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class EngineeringEmployee : Employee
    {
        private Person _personInfo;
        private double _salary;
        public EngineeringEmployeeType EnginerEmployeeType { get; private set; }
        public EngineeringEmployee(Person person, double salary, EngineeringEmployeeType enginerEmployeeType) : base(person, salary)
        {
            EnginerEmployeeType = enginerEmployeeType;
        }

        public override Person PersonInfo { get => _personInfo; protected set => _personInfo = value; }
        public override double Salary { get => _salary; protected set => _salary = value; }

        public override void GetBonuses(double bonusPercent)
        {
            _salary += _salary * (bonusPercent / 100);
        }

        public override string GetEmployeeType()
        {
            return EnginerEmployeeType.ToString();
        }

        public override string GetInfo()
        {
            return $"EngineeringEmployee \n{_personInfo} \nSalary: {_salary} \n Type: {EnginerEmployeeType}";
        }
    }
}
