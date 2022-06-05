using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class Teacher : Employee
    {

        private const double BONUS_KOEF_FOR_TEACHER = 1.2;
        private Person _personInfo;
        private double _salary;
        public TeacherType TeacherType { get; private set; } 
        public Teacher(Person person,double salary, TeacherType teacherType) : base(person, salary)
        {
            TeacherType = teacherType;
        }

        public override Person PersonInfo { get => _personInfo; protected set => _personInfo = value; }
        public override double Salary { get => _salary; protected set => _salary = value; }

        public override void GetBonuses(double bonusPercent)
        {
            _salary += _salary * BONUS_KOEF_FOR_TEACHER * (bonusPercent / 100);
        }

        public override string GetEmployeeType()
        {
            return TeacherType.ToString();
        }

        public override string GetInfo()
        {
            return $"Teacher \n{_personInfo} \nSalary: {_salary} \n Type: {TeacherType}";
        }
    }
}
