using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class Articoli
    {
        public Articoli()
        {
            ArticoliListini = new HashSet<ArticoliListini>();
            MovimentiRighe = new HashSet<MovimentiRighe>();
        }

        public int Id { get; set; }
        public string Descrizione { get; set; }
        public double? Prezzo { get; set; }
        public double? Costo { get; set; }
        public int? Giacenza { get; set; }
        public int? Disponibilita { get; set; }

        public virtual ICollection<ArticoliListini> ArticoliListini { get; set; }
        public virtual ICollection<MovimentiRighe> MovimentiRighe { get; set; }
    }
}
