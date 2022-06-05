using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork2
{
    public class PersonDTO
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("kidsAmount")]
        public int KidsAmount { get; set; }

        [JsonProperty("IsEmployee")]
        public bool IsEmployee { get; set; }

    }
}
