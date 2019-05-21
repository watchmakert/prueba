using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busisnes.AerolineasBusisness.Interfaces
{
    public interface IAerolineasServices
    {
        List<Aerolinea> GetAerolineas();
        void AgregarAerolinea(string name, int idpais);
        Aerolinea ConsultarAerolinea(int identificacion);
        void BorrarAerolinea(int identificacion);
    }
}
