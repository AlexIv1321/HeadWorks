using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Core.Models
{
    public class Hero
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }
        public int Weapon { get; set; }
        public ICollection<Hit> Hit { get; set; }
    }
}
