using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ErpDemoEF.Models
{
    public partial class CausaliMagazzino
    {
        public CausaliMagazzino()
        {
            Movimenti = new HashSet<Movimenti>();
        }

        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public int AzioneGiacenza { get; set; }
        public int AzioneDisponibilita { get; set; }

        public virtual ICollection<Movimenti> Movimenti { get; set; }
    }
}
