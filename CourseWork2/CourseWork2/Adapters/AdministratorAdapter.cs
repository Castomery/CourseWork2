using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class AdministratorAdapter : IAdapter<Administrator, AdministratorDTO>
    {
        public AdministratorDTO ConvertToDTO(Administrator model)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new AdministratorDTO() { PersonDTO = personAdapter.ConvertToDTO(model.PersonInfo), Salary = model.Salary };
        }

        public Administrator ConvertToModel(AdministratorDTO dto)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new Administrator(personAdapter.ConvertToModel(dto.PersonDTO), dto.Salary);
        }
    }
}
