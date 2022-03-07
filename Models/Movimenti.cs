using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class Movimenti
    {
        public Movimenti()
        {
            MovimentiRighe = new HashSet<MovimentiRighe>();
        }

        public int id { get; set; }
        public string Causale { get; set; }
        public DateTime Data { get; set; }
        public int? Cliente { get; set; }

        public virtual CausaliMagazzino CausaleNavigation { get; set; }
        public virtual Clienti ClienteNavigation { get; set; }
        public virtual ICollection<MovimentiRighe> MovimentiRighe { get; set; }
    }
}
