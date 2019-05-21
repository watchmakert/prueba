using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Ruta
    {
        public int Id { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public int IdAeronave { get; set; }
        public int IdOrigen { get; set; }
        public int IdDestino { get; set; }

        public virtual Aeronave IdAeronaveNavigation { get; set; }
        public virtual Pais IdDestinoNavigation { get; set; }
        public virtual Pais IdOrigenNavigation { get; set; }
    }
}
