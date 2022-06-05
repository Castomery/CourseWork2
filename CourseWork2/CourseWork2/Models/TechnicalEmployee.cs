using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class TechnicalEmployee : Employee
    {
        
        private const double BONUS_KOEF_FOR_TECHNICALEMPLOYEE = 1.5;

        private Person _personInfo;
        private double _salary;
        public TechnicalEmployeeType TechnicalEmployeeType { get; private set; }
        public TechnicalEmployee(Person person, double salary, TechnicalEmployeeType technicalWorkerType) : base(person, salary)
        {
            TechnicalEmployeeType = technicalWorkerType;
        }

        public override Person PersonInfo { get => _personInfo; protected set => _personInfo = value; }
        public override double Salary { get => _salary; protected set => _salary = value; }

        public override void GetBonuses(double bonusPercent)
        {
            _salary += _salary * BONUS_KOEF_FOR_TECHNICALEMPLOYEE * (bonusPercent / 100);
        }

        public override string GetEmployeeType()
        {
            return TechnicalEmployeeType.ToString();
        }

        public override string GetInfo()
        {
            return $"TechnicalEmployee \n{_personInfo} \nSalary: {_salary} \n Type: {TechnicalEmployeeType}";
        }
    }
}
