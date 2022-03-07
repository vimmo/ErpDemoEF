using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class Clienti
    {
        public Clienti()
        {
            Movimenti = new HashSet<Movimenti>();
        }

        public int Id { get; set; }
        public string RagioneSociale { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public int? Listino { get; set; }
        public bool? IsFornitore { get; set; }

        public virtual Listini ListinoNavigation { get; set; }
        public virtual ICollection<Movimenti> Movimenti { get; set; }
    }
}
