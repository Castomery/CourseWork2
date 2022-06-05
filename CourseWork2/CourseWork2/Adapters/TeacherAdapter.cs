using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class TeacherAdapter : IAdapter<Teacher, TeacherDTO>
    {
        public TeacherDTO ConvertToDTO(Teacher model)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new TeacherDTO() { PersonDTO = personAdapter.ConvertToDTO(model.PersonInfo), Salary = model.Salary, TeacherType = model.TeacherType};
        }

        public Teacher ConvertToModel(TeacherDTO dto)
        {
            PersonAdapter personAdapter = new PersonAdapter();

            return new Teacher(personAdapter.ConvertToModel(dto.PersonDTO), dto.Salary, dto.TeacherType);
        }
    }
}
