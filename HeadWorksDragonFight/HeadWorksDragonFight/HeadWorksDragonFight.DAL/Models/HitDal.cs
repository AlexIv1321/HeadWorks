using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Dal.Models
{
    public class HitDal
    {
        public Guid Id { get; set; }
        public Guid HeroDalId { get; set; }
        public Guid DragonDalId { get; set; }
        public string NameDragon { get; set; }
        public int ImpactForce { get; set; }
        public decimal StrikeTime { get; set; }
        public HeroDal HeroDal { get; set; }
    }
}
