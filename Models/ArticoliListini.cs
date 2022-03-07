using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class ArticoliListini
    {
        public int Articolo { get; set; }
        public int Listino { get; set; }
        public double? Prezzo { get; set; }

        public virtual Articoli ArticoloNavigation { get; set; }
        public virtual Listini ListinoNavigation { get; set; }
    }
}
