using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class InfoLoader
    {
        private string _pathEmployee;
        private string _pathPeople;

        public InfoLoader(string pathEmployee, string pathPeople)
        {
            _pathEmployee = pathEmployee;
            _pathPeople = pathPeople;
        }

        public void SaveEmployeesData(List<Employee> employees)
        {
            EmployeeListDTO employeeListDTO = new EmployeeListDTO();

            foreach (var item in employees)
            {
                employeeListDTO.AddEmployee(item);
            }

            Serializator<EmployeeListDTO> serializator = new Serializator<EmployeeListDTO>(_pathEmployee);
            serializator.Serialize(employeeListDTO);
        }

        public List<Employee> LoadEmployeesData()
        {
            AdministratorAdapter administratorAdapter = new AdministratorAdapter();
            EngineeringEmployeeAdapter engineeringEmployeeAdapter = new EngineeringEmployeeAdapter();
            TeacherAdapter teacherAdapter = new TeacherAdapter();
            TechnicalEmployeeAdapter technicalEmployeeAdapter = new TechnicalEmployeeAdapter();

            Serializator<EmployeeListDTO> serializator = new Serializator<EmployeeListDTO>(_pathEmployee);
            EmployeeListDTO employeeListDTO;
            try
            {
                employeeListDTO = serializator.Deserialize();
            }
            catch (Exception)
            {
                return new List<Employee>();
            }
            
            

            List<Employee> employees = new List<Employee>();

            foreach (var item in employeeListDTO.administratorDTOs)
            {
                employees.Add(administratorAdapter.ConvertToModel(item));
            }

            foreach (var item in employeeListDTO.engineeringEmployeeDTOs)
            {
                employees.Add(engineeringEmployeeAdapter.ConvertToModel(item));
            }

            foreach (var item in employeeListDTO.teacherDTOs)
            {
                employees.Add(teacherAdapter.ConvertToModel(item));
            }

            foreach (var item in employeeListDTO.technicalEmployeeDTOs)
            {
                employees.Add(technicalEmployeeAdapter.ConvertToModel(item));
            }

            return employees;
        }

        public void SavePeopleData(List<Person> people)
        {
            PeopleDTO peopleDTO = new PeopleDTO();

            foreach (var item in people)
            {
                peopleDTO.AddPerson(item);
            }
            Serializator<PeopleDTO> serializator = new Serializator<PeopleDTO>(_pathPeople);
            serializator.Serialize(peopleDTO);
        }

        public List<Person> LoadPeopleData()
        {
            PersonAdapter personAdapter = new PersonAdapter();

            Serializator<PeopleDTO> serializator = new Serializator<PeopleDTO>(_pathPeople);
            PeopleDTO peopleDTO;
            try
            {
                peopleDTO = serializator.Deserialize();
            }
            catch (Exception)
            {
                return new List<Person>();
            }

            List<Person> people = new List<Person>();
            foreach (var item in peopleDTO.personDTOs)
            {
                people.Add(personAdapter.ConvertToModel(item));
            }

            return people;
        }
    }
}
