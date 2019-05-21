using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Prestamo
    {
        public int Id { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public int IdPropietario { get; set; }
        public int IdPrestador { get; set; }
        public int Idaeronave { get; set; }

        public virtual Aerolinea IdPrestadorNavigation { get; set; }
        public virtual Aerolinea IdPropietarioNavigation { get; set; }
        public virtual Aeronave IdaeronaveNavigation { get; set; }
    }
}
