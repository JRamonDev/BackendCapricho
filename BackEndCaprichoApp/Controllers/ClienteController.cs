using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteService _oClienteService;
        public ClienteController(IClienteService oClienteService)
        {
            _oClienteService = oClienteService;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _oClienteService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetCliente")]
        public Cliente Get(int id)
        {
            return _oClienteService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Cliente oCliente)
        {
            if (ModelState.IsValid) _oClienteService.Add(oCliente);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Cliente oCliente)
        {
            if (ModelState.IsValid) _oClienteService.Update(oCliente);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oClienteService.Delete(id);
        }
    }
}
