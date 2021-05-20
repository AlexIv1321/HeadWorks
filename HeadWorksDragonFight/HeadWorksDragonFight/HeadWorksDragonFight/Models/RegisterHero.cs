using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HeadWorksDragonFight.Models
{
    public class RegisterHero
    {
       /* [JsonPropertyName("id")]
        public Guid Id { get; set; }*/

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
