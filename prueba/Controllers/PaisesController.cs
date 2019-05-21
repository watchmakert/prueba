using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Busisnes.Paises.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisesServices _IPaisesServices;

        public PaisesController(IPaisesServices _IPaisesServices)
        {
            this._IPaisesServices = _IPaisesServices;
        }
        // GET: api/Paises
        [HttpGet]
        public ActionResult<List<Pais>> Get()
        {
            List<Pais> lstPais = _IPaisesServices.GetPaises();
            return lstPais;
        }

        // GET: api/Paises/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Pais> Get(int id)
        {
            Pais pais = _IPaisesServices.ConsultarPais(id);
            return pais;
        }

        // POST: api/Paises
        [HttpPost]
        public void Post([FromBody] Pais pais)
        {
            _IPaisesServices.AgregarPais(pais.Nombre, pais.Latitud, pais.Longitud);
        }

        // PUT: api/Paises/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _IPaisesServices.BorrarPais(id);
        }
    }
}
