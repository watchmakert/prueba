using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Aerolinea
    {
        public Aerolinea()
        {
            Aeronave = new HashSet<Aeronave>();
            PrestamoIdPrestadorNavigation = new HashSet<Prestamo>();
            PrestamoIdPropietarioNavigation = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public int IdPais { get; set; }

        public virtual Pais IdPaisNavigation { get; set; }
        public virtual ICollection<Aeronave> Aeronave { get; set; }
        public virtual ICollection<Prestamo> PrestamoIdPrestadorNavigation { get; set; }
        public virtual ICollection<Prestamo> PrestamoIdPropietarioNavigation { get; set; }
    }
}
