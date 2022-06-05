using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    class EmployeeListDTO
    {
        public List<AdministratorDTO> administratorDTOs { get; private set; }
        public List<EngineeringEmployeeDTO> engineeringEmployeeDTOs { get; private set; }
        public List<TeacherDTO> teacherDTOs { get; private set; }
        public List<TechnicalEmployeeDTO> technicalEmployeeDTOs { get; private set; }

        public EmployeeListDTO()
        {
            administratorDTOs = new List<AdministratorDTO>();
            engineeringEmployeeDTOs = new List<EngineeringEmployeeDTO>();
            teacherDTOs = new List<TeacherDTO>();
            technicalEmployeeDTOs = new List<TechnicalEmployeeDTO>();
        }

        public void AddEmployee(Employee employee)
        {
            AdministratorAdapter administratorAdapter = new AdministratorAdapter();
            EngineeringEmployeeAdapter engineeringEmployeeAdapter = new EngineeringEmployeeAdapter();
            TeacherAdapter teacherAdapter = new TeacherAdapter();
            TechnicalEmployeeAdapter technicalEmployeeAdapter = new TechnicalEmployeeAdapter();

            if (employee is Administrator)
            {
                administratorDTOs.Add(administratorAdapter.ConvertToDTO((Administrator)employee));
            }
            else if (employee is EngineeringEmployee)
            {
                engineeringEmployeeDTOs.Add(engineeringEmployeeAdapter.ConvertToDTO((EngineeringEmployee)employee));
            }
            else if (employee is Teacher)
            {
                teacherDTOs.Add(teacherAdapter.ConvertToDTO((Teacher)employee));
            }
            else if (employee is TechnicalEmployee)
            {
                technicalEmployeeDTOs.Add(technicalEmployeeAdapter.ConvertToDTO((TechnicalEmployee)employee));
            }
        }
    }
}
