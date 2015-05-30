using System;
using System.Collections.Generic;

namespace HB8.CSMS.DAL.Models
{
    public partial class UnitClass
    {
        public UnitClass()
        {
            this.Units = new List<Unit>();
        }

        public int UnitClassId { get; set; }
        public string ClassName { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
