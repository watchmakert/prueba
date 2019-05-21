using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Aeronave
    {
        public Aeronave()
        {
            Prestamo = new HashSet<Prestamo>();
            Ruta = new HashSet<Ruta>();
        }

        public int Id { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public bool Estado { get; set; }
        public int IdAerolinea { get; set; }

        public virtual Aerolinea IdAerolineaNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamo { get; set; }
        public virtual ICollection<Ruta> Ruta { get; set; }
    }
}
