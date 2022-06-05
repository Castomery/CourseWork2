using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class PersonAdapter : IAdapter<Person, PersonDTO>
    {
        public PersonDTO ConvertToDTO(Person model)
        {
            return new PersonDTO() {Id = model.Id, Name = model.Name, Surname = model.Surname, Age = model.Age, KidsAmount = model.KidsAmount, IsEmployee = model.IsEmployee};
        }

        public Person ConvertToModel(PersonDTO dto)
        {
            return new Person(dto.Name, dto.Surname, dto.Age, dto.KidsAmount, dto.IsEmployee, dto.Id);
        }
    }
}
