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
    public class CarritoService:ICarritoService
    {
        Carrito _oCarrito = new Carrito();
        List<Carrito> _oCarritos = new List<Carrito>();
        public Carrito Add(Carrito oCarrito)
        {
            _oCarrito = new Carrito();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCarritos = con.Query<Carrito>("usp_InsertCarrito", this.setParameters(oCarrito),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCarrito.Error = ex.Message;
            }
            return _oCarrito;
        }
        public string Delete(int IdCarrito)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@CarritoId", IdCarrito);
                        con.Query("usp_DeleteCarrito", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCarrito.Error = ex.Message;
            }
            return _oCarrito.Error;
        }
        public Carrito Get(int IdCarrito)
        {
            _oCarrito = new Carrito();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@CarritoId", IdCarrito); var oCarrito = con.Query<Carrito>("usp_SelectCarrito", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oCarrito != null && oCarrito.Count() > 0)
                    {
                        _oCarrito = oCarrito.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCarrito.Error = ex.Message;
            }
            return _oCarrito;
        }
        public List<Carrito> Gets()
        {
            _oCarritos = new List<Carrito>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oCarritos = con.Query<Carrito>("usp_SelectCarritoAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oCarritos != null && oCarritos.Count() > 0)
                    {
                        _oCarritos = oCarritos;
                    }
                }
            }
            catch (Exception ex)
            {
                _oCarrito.Error = ex.Message;
            }
            return _oCarritos;
        }
        public Carrito Update(Carrito oCarrito)
        {
            _oCarrito = new Carrito();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oCarritos = con.Query<Carrito>("usp_UpdateCarrito", this.setParameters(oCarrito),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCarrito.Error = ex.Message;
            }
            return _oCarrito;
        }
        private DynamicParameters setParameters(Carrito oCarrito)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oCarrito.CarritoId != 0) parameters.Add("@CarritoId", oCarrito.CarritoId);
            parameters.Add("@VentaId", oCarrito.VentaId);
            parameters.Add("@ProductoId", oCarrito.ProductoId);
            parameters.Add("@ProductoPrecio", oCarrito.ProductoPrecio);
            parameters.Add("@Cantidad", oCarrito.Cantidad);
            return parameters;
        }
    }
}
