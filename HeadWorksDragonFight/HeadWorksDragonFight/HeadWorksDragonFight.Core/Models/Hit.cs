using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Core.Models
{
    public class Hit
    {
        public Guid Id { get; set; }
        public Guid HeroId { get; set; }
        public Guid DragonId { get; set; }
        public string NameDragon { get; set; }
        public int ImpactForce { get; set; }
        public decimal StrikeTime { get; set; }
    }
}
