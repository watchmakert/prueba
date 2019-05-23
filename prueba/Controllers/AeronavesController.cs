using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busisnes.AeronavesBusisness.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeronavesController : ControllerBase
    {
        private readonly IAeronavesServices _IAeronavesServices;

        public AeronavesController(IAeronavesServices _IAeronavesServices)
        {
            this._IAeronavesServices = _IAeronavesServices;
        }

        [HttpGet]
        public ActionResult<List<Aeronave>> Get()
        {
            List<Aeronave> lstAeronaves = _IAeronavesServices.GetAeronave();
            return lstAeronaves;
        }

        [HttpGet("{id}")]
        public ActionResult<Aeronave> Get(int id)
        {
            Aeronave aeronave = _IAeronavesServices.ConsultarAeronave(id);
            return aeronave;
        }
        [HttpPost]
        public void Post([FromBody] Aeronave aeronave)
        {
            _IAeronavesServices.AgregarAeronave(aeronave.Latitud, aeronave.Longitud, aeronave.Estado, aeronave.IdAerolinea);
        }
        [HttpDelete("{id}")]
        public void delete(int id)
        {
            _IAeronavesServices.BorrarAeronave(id);
        }

        [HttpPut]
        public void Put([FromBody] Aeronave aeronave)
        {
            _IAeronavesServices.ActualizarAeronave(aeronave.Id, aeronave.Latitud, aeronave.Longitud, aeronave.Estado);
        }
    }
}