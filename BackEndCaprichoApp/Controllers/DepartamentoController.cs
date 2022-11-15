using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private IDepartamentoService _oDepartamentoService;
        public DepartamentoController(IDepartamentoService oDepartamentoService)
        {
            _oDepartamentoService = oDepartamentoService;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return _oDepartamentoService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetDepartamento")]
        public Departamento Get(int id)
        {
            return _oDepartamentoService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Departamento oDepartamento)
        {
            if (ModelState.IsValid) _oDepartamentoService.Add(oDepartamento);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Departamento oDepartamento)
        {
            if (ModelState.IsValid) _oDepartamentoService.Update(oDepartamento);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oDepartamentoService.Delete(id);
        }
    }
}
