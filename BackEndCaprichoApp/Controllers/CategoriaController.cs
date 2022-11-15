using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService _oCategoriaService;
        public CategoriaController(ICategoriaService oCategoriaService)
        {
            _oCategoriaService = oCategoriaService;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _oCategoriaService.Gets();
        }
        // GET api/<CategoriaController>/5
        [HttpGet("{id}", Name = "GetCategoria")]
        public Categoria Get(int id)
        {
            return _oCategoriaService.Get(id);
        }
        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] Categoria oCategoria)
        {
            if (ModelState.IsValid) _oCategoriaService.Add(oCategoria);
        }
        // PUT api/<CategoriaController>/5
        [HttpPut]
        public void Put([FromBody] Categoria oCategoria)
        {
            if (ModelState.IsValid) _oCategoriaService.Update(oCategoria);
        }
        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oCategoriaService.Delete(id);
        }
    }
}
