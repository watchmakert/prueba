using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busisnes.AeronavesBusisness.Interfaces
{
    public interface IAeronavesServices
    {
        List<Aeronave> GetAeronave();
        void AgregarAeronave(decimal latitud, decimal longitud, bool estado, int idAerolinea);       
        Aeronave ConsultarAeronave(int identificacion);
        void BorrarAeronave(int identificacion);
        void ActualizarAeronave(int identificacion, decimal latitud, decimal longitud, bool estado);


    }
}
