using System;
using Data.Models;
using System.Collections.Generic;
using System.Text;

namespace Busisnes.Paises.Interfaces
{
    public interface IPaisesServices
    {
        List<Pais> GetPaises();
        void AgregarPais(string name, decimal latitud, decimal longitud);
        void BorrarPais(int identification);
        Pais ConsultarPais(int identification);
    }
}
