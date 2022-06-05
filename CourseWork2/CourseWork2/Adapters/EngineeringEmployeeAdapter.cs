using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class EngineeringEmployeeAdapter : IAdapter<EngineeringEmployee, EngineeringEmployeeDTO>
    {
        public EngineeringEmployeeDTO ConvertToDTO(EngineeringEmployee model)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new EngineeringEmployeeDTO() { PersonDTO = personAdapter.ConvertToDTO(model.PersonInfo), Salary = model.Salary, EngineeringEmployeeType = model.EnginerEmployeeType };
        }

        public EngineeringEmployee ConvertToModel(EngineeringEmployeeDTO dto)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new EngineeringEmployee(personAdapter.ConvertToModel(dto.PersonDTO), dto.Salary, dto.EngineeringEmployeeType);
        }
    }
}
