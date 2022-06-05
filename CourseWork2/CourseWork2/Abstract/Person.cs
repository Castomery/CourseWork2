using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } 
        public string Surname { get; private set; } 
        public int Age { get; private set; } 
        public int KidsAmount { get; private set; }
        public bool IsEmployee { get; set; }

        public Person(string name, string surname, int age, int kidsAmount, bool isEmployee, Guid id)
        {
            if (name == null|| name == "" || surname == null || surname == "")
            {
                throw new InvalidPersonDataException(name, surname);
            }

            if (age <= 0 || age >= 125)
            {
                throw new InvalidPersonDataException(age);
            }

            if (kidsAmount < 0)
            {
                throw new Exception("Invalide kidsAmount data");
            }

            Name = name;
            Surname = surname;
            Age = age;
            KidsAmount = kidsAmount;
            IsEmployee = isEmployee;
            Id = id;
        }

        public override string ToString()
        {
           return $"{Name} {Surname} Age: {Age} KidsAmount: {KidsAmount}";
        }
    }
}
