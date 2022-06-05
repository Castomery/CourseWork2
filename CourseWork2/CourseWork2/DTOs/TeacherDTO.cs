using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class TeacherDTO
    {
        [JsonProperty("person_info")]
        public PersonDTO PersonDTO { get; set; }

        [JsonProperty("salary")]
        public double Salary { get; set; }

        [JsonProperty("engineeringEmployee_type")]
        public TeacherType TeacherType { get; set; }
    }
}
