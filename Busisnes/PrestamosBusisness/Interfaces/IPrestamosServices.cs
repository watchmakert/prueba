using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Busisnes.PrestamosBusisness.Interfaces
{
    public interface IPrestamosServices
    {
        List<Prestamo> GetPrestamos();
        Prestamo ConsultarPrestamo(int identificacion);
        void AgregarPrestamo(DateTime inicio, DateTime final, int idPopietario, int idPrestador, int idAeronave);
        void BorrarPrestamo(int identificacion);
        List<Prestamo> GetPrestamosActuales();
    }
}
