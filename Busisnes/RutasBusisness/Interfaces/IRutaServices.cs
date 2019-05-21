using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busisnes.RutasBusisness.Interfaces
{
    public interface IRutaServices
    {
        List<Ruta> GetRutas();
        void AgregarRutas(DateTime inicio, DateTime final, int idAeronave, int idOrigen, int idDestino);
        void BorrarRuta(int identificacion);
        Ruta ConsultarRuta(int identificacion);
    }
}
