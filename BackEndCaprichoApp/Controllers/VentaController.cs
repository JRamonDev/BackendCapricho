using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private IVentaService _oVentaService;
        public VentaController(IVentaService oVentaService)
        {
            _oVentaService = oVentaService;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Venta> Get()
        {
            return _oVentaService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetVenta")]
        public Venta Get(int id)
        {
            return _oVentaService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Venta oVenta)
        {
            if (ModelState.IsValid) _oVentaService.Add(oVenta);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Venta oVenta)
        {
            if (ModelState.IsValid) _oVentaService.Update(oVenta);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oVentaService.Delete(id);
        }
    }
}
