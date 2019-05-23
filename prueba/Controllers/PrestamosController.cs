using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busisnes.PrestamosBusisness.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamosServices _IPrestamosServices;

        public PrestamosController(IPrestamosServices _IPrestamosServices)
        {
            this._IPrestamosServices = _IPrestamosServices;
        }

        [HttpGet]
        public ActionResult<List<Prestamo>> Get()
        {
            List<Prestamo> prestamo = _IPrestamosServices.GetPrestamosActuales();
            return prestamo;
        }
        [HttpGet("{id}")]
        public ActionResult<Prestamo> Get(int id)
        {
            Prestamo prestamo = _IPrestamosServices.ConsultarPrestamo(id);
            return prestamo;
        }

        [HttpPost]
        public void Post([FromBody] Prestamo prestamo)
        {
            _IPrestamosServices.AgregarPrestamo(prestamo.Fechainicio, prestamo.Fechafin, prestamo.IdPropietario, prestamo.IdPrestador, prestamo.Idaeronave);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IPrestamosServices.BorrarPrestamo(id);
        }
    }
}