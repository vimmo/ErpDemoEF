using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class Listini
    {
        public Listini()
        {
            ArticoliListini = new HashSet<ArticoliListini>();
            Clienti = new HashSet<Clienti>();
        }

        public int id { get; set; }
        public string Descrizione { get; set; }

        public virtual ICollection<ArticoliListini> ArticoliListini { get; set; }
        public virtual ICollection<Clienti> Clienti { get; set; }
    }
}
