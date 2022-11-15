using BackEndCaprichoApp.Iservices;
using BackEndCaprichoApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using BackEndCaprichoApp.Conexión;
using System;

namespace BackEndCaprichoApp.Services
{
    public class ProductoService : IProductoService
    {
        Producto _oProducto = new Producto();
        List<Producto> _oProductos = new List<Producto>();
        public Producto Add(Producto oProducto)
        {
            _oProducto = new Producto();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oProductos = con.Query<Producto>("usp_InsertProducto", this.setParameters(oProducto),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oProducto.Error = ex.Message;
            }
            return _oProducto;
        }
        public string Delete(int IdProducto)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@ProductoId", IdProducto);
                        con.Query("usp_DeleteProducto", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oProducto.Error = ex.Message;
            }
            return _oProducto.Error;
        }
        public Producto Get(int IdProducto)
        {
            _oProducto = new Producto();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@ProductoId", IdProducto); var oProducto = con.Query<Producto>("usp_SelectProducto", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oProducto != null && oProducto.Count() > 0)
                    {
                        _oProducto = oProducto.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oProducto.Error = ex.Message;
            }
            return _oProducto;
        }
        public List<Producto> Gets()
        {
            _oProductos = new List<Producto>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oProductos = con.Query<Producto>("usp_SelectProductoAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oProductos != null && oProductos.Count() > 0)
                    {
                        _oProductos = oProductos;
                    }
                }
            }
            catch (Exception ex)
            {
                _oProducto.Error = ex.Message;
            }
            return _oProductos;
        }
        public Producto Update(Producto oProducto)
        {
            _oProducto = new Producto();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oProductos = con.Query<Producto>("usp_UpdateProducto", this.setParameters(oProducto),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oProducto.Error = ex.Message;
            }
            return _oProducto;
        }
        private DynamicParameters setParameters(Producto oProducto)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oProducto.ProductoId != 0) parameters.Add("@ProductoId", oProducto.ProductoId);
            parameters.Add("@ProductoNombre", oProducto.ProductoNombre);
            parameters.Add("@Precio", oProducto.Precio);
            parameters.Add("@Categoria", oProducto.Categoria);
            parameters.Add("@Fecha_registro", oProducto.Fecha_registro);
            parameters.Add("@PhotoFileName", oProducto.PhotoFileName);
            return parameters;
        }
    }
}
