using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Dal.Models
{
    public class HeroDal
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }
        public int Weapon { get; set; }
        public ICollection<HitDal> HitDal { get; set; }
    }
}
