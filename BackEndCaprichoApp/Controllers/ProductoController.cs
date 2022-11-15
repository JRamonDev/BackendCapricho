using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BackEndCaprichoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private IProductoService _oProductoService;

        public ProductoController(IProductoService oProductoService, IConfiguration configuration, IWebHostEnvironment env)
        {
            _oProductoService = oProductoService;
            _configuration = configuration;
            _env = env;
        }
        // GET: api/<CarritoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _oProductoService.Gets();
        }
        // GET api/<CarritoController>/5
        [HttpGet("{id}", Name = "GetProducto")]
        public Producto Get(int id)
        {
            return _oProductoService.Get(id);
        }
        // POST api/<CarritoController>
        [HttpPost]
        public void Post([FromBody] Producto oProducto)
        {
            if (ModelState.IsValid) _oProductoService.Add(oProducto);
        }
        // PUT api/<CarritoController>/5
        [HttpPut]
        public void Put([FromBody] Producto oProducto)
        {
            if (ModelState.IsValid) _oProductoService.Update(oProducto);
        }
        // DELETE api/<CarritoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id != 0) _oProductoService.Delete(id);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [Route("GetAllCategoriesNames")]
        public JsonResult GetAllCategoriesNames()
        {
            string query = @"
                    select CategoriaNombre from dbo.Categoria
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MyDb");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
