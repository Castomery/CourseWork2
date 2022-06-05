using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class PeopleDTO
    {
        public List<PersonDTO> personDTOs { get; private set; }

        public PeopleDTO()
        {
            personDTOs = new List<PersonDTO>();
        }

        public void AddPerson(Person person)
        {
            PersonAdapter personAdapter = new PersonAdapter();
            personDTOs.Add(personAdapter.ConvertToDTO(person));
        }
    }
}
