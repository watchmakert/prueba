using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Pais
    {
        public Pais()
        {
            Aerolinea = new HashSet<Aerolinea>();
            RutaIdDestinoNavigation = new HashSet<Ruta>();
            RutaIdOrigenNavigation = new HashSet<Ruta>();
        }

        public int Id { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Aerolinea> Aerolinea { get; set; }
        public virtual ICollection<Ruta> RutaIdDestinoNavigation { get; set; }
        public virtual ICollection<Ruta> RutaIdOrigenNavigation { get; set; }
    }
}
