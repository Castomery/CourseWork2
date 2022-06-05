using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class People
    {
        public List<Person> PersonList { get; private set; }

        public People()
        {
            PersonList = new List<Person>();
        }

        public People(List<Person> people)
        {
            PersonList = people;
        }

        public Person GetPersonById(Guid id)
        {
            foreach (var item in PersonList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void AddPerson(Person person)
        {
            if (!PersonList.Contains(person))
            {
                PersonList.Add(person);
            }
        }

        public void RemovePerson(Person person)
        {
            if (PersonList.Contains(person))
            {
                PersonList.Remove(person);
            }
        }
    }
}
