using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private IMunicipioService _oMunicipioService;
        public MunicipioController(IMunicipioService oMunicipioService)
        {
            _oMunicipioService = oMunicipioService;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Municipio> Get()
        {
            return _oMunicipioService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetMunicipio")]
        public Municipio Get(int id)
        {
            return _oMunicipioService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Municipio oMunicipio)
        {
            if (ModelState.IsValid) _oMunicipioService.Add(oMunicipio);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Municipio oMunicipio)
        {
            if (ModelState.IsValid) _oMunicipioService.Update(oMunicipio);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oMunicipioService.Delete(id);
        }
    }
}
