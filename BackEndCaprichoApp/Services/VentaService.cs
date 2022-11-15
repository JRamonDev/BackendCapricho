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
    public class VentaService : IVentaService
    {
        Venta _oVenta = new Venta();
        List<Venta> _oVentas = new List<Venta>();
        public Venta Add(Venta oVenta)
        {
            _oVenta = new Venta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oVentas = con.Query<Venta>("usp_InsertVentas", this.setParameters(oVenta),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oVenta.Error = ex.Message;
            }
            return _oVenta;
        }
        public string Delete(int IdVenta)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@VentaId", IdVenta);
                        con.Query("usp_DeleteVentas", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oVenta.Error = ex.Message;
            }
            return _oVenta.Error;
        }
        public Venta Get(int IdVenta)
        {
            _oVenta = new Venta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@VentaId", IdVenta); var oVenta = con.Query<Venta>("usp_SelectVentas", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oVenta != null && oVenta.Count() > 0)
                    {
                        _oVenta = oVenta.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oVenta.Error = ex.Message;
            }
            return _oVenta;
        }
        public List<Venta> Gets()
        {
            _oVentas = new List<Venta>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oVentas = con.Query<Venta>("usp_SelectVentasAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oVentas != null && oVentas.Count() > 0)
                    {
                        _oVentas = oVentas;
                    }
                }
            }
            catch (Exception ex)
            {
                _oVenta.Error = ex.Message;
            }
            return _oVentas;
        }
        public Venta Update(Venta oVenta)
        {
            _oVenta = new Venta();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oVentas = con.Query<Venta>("usp_UpdateVentas", this.setParameters(oVenta),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oVenta.Error = ex.Message;
            }
            return _oVenta;
        }
        private DynamicParameters setParameters(Venta oVenta)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oVenta.VentaId != 0) parameters.Add("@VentaId", oVenta.VentaId);
            parameters.Add("@ClienteId", oVenta.ClienteId);
            parameters.Add("@Fecha_registro", oVenta.Fecha_registro);
            parameters.Add("@Municipio", oVenta.Municipio);
            parameters.Add("@MTotal", oVenta.MTotal);
            return parameters;
        }
    }
}
