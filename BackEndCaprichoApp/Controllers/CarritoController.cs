using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private ICarritoService _oCarritoService;
        public CarritoController(ICarritoService oCarritoService)
        {
            _oCarritoService = oCarritoService;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Carrito> Get()
        {
            return _oCarritoService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetCarrito")]
        public Carrito Get(int id)
        {
            return _oCarritoService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Carrito oCarrito)
        {
            if (ModelState.IsValid) _oCarritoService.Add(oCarrito);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Carrito oCarrito)
        {
            if (ModelState.IsValid) _oCarritoService.Update(oCarrito);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oCarritoService.Delete(id);
        }
    }
}

