using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busisnes.RutasBusisness.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly IRutaServices _IRutasServices;

        public RutasController(IRutaServices _IRutasServices)
        {
            this._IRutasServices = _IRutasServices;
        }
        // GET: api/Rutas
        [HttpGet]
        public ActionResult<List<Ruta>> Get()
        {
            List<Ruta> rutas = _IRutasServices.GetRutas();
            return rutas;
        }
        // GET: api/Rutas/5
        [HttpGet("{id}")]
        public ActionResult<Ruta> Get(int id)
        {
            Ruta ruta = _IRutasServices.ConsultarRuta(id);
            return ruta;
        }

        [HttpPost]
        public void Post([FromBody] Ruta ruta)
        {
            _IRutasServices.AgregarRutas(ruta.Fechainicio, ruta.Fechafin, ruta.IdAeronave, ruta.IdOrigen, ruta.IdDestino);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IRutasServices.BorrarRuta(id);
        }
    }
}