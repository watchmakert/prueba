using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busisnes.AerolineasBusisness.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AerolineasController : ControllerBase
    {
        private readonly IAerolineasServices _IAerolineasServices;

        public AerolineasController(IAerolineasServices _IAerolineasServices)
        {
            this._IAerolineasServices = _IAerolineasServices;
        }

        [HttpGet]
        public ActionResult<List<Aerolinea>> Get()
        {
            List<Aerolinea> lstAerolineas = _IAerolineasServices.GetAerolineas();
            return lstAerolineas;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Aerolinea> Get(int id)
        {
            Aerolinea aerolinea = _IAerolineasServices.ConsultarAerolinea(id);
            return aerolinea;
        }
        [HttpPost]
        public void post([FromBody] Aerolinea aerolinea)
        {
            _IAerolineasServices.AgregarAerolinea(aerolinea.Nombre,aerolinea.IdPais);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            _IAerolineasServices.BorrarAerolinea(id);
        }
    }
}