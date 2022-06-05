using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class TechnicalEmployeeAdapter : IAdapter<TechnicalEmployee, TechnicalEmployeeDTO>
    {
        public TechnicalEmployeeDTO ConvertToDTO(TechnicalEmployee model)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new TechnicalEmployeeDTO() { PersonDTO = personAdapter.ConvertToDTO(model.PersonInfo), Salary = model.Salary, TechnicalEmployeeType = model.TechnicalEmployeeType };
        }

        public TechnicalEmployee ConvertToModel(TechnicalEmployeeDTO dto)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new TechnicalEmployee(personAdapter.ConvertToModel(dto.PersonDTO), dto.Salary, dto.TechnicalEmployeeType);
        }
    }
}
