using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Core.Models
{
    public class Dragon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int HpMax { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Hit> Hit { get; set; }
    }
}
