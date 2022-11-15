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
    public class ClienteService : IClienteService
    {
        Cliente _oCliente = new Cliente();
        List<Cliente> _oClientes = new List<Cliente>();
        public Cliente Add(Cliente oCliente)
        {
            _oCliente = new Cliente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oClientes = con.Query<Cliente>("usp_InsertClientes", this.setParameters(oCliente),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCliente.Error = ex.Message;
            }
            return _oCliente;
        }
        public string Delete(int IdCliente)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@ClienteId", IdCliente);
                        con.Query("usp_DeleteClientes", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCliente.Error = ex.Message;
            }
            return _oCliente.Error;
        }
        public Cliente Get(int IdCliente)
        {
            _oCliente = new Cliente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@ClienteId", IdCliente); var oCliente = con.Query<Cliente>("usp_SelectClientes", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oCliente != null && oCliente.Count() > 0)
                    {
                        _oCliente = oCliente.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCliente.Error = ex.Message;
            }
            return _oCliente;
        }
        public List<Cliente> Gets()
        {
            _oClientes = new List<Cliente>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oClientes = con.Query<Cliente>("usp_SelectClientesAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oClientes != null && oClientes.Count() > 0)
                    {
                        _oClientes = oClientes;
                    }
                }
            }
            catch (Exception ex)
            {
                _oCliente.Error = ex.Message;
            }
            return _oClientes;
        }
        public Cliente Update(Cliente oCliente)
        {
            _oCliente = new Cliente();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oClientes = con.Query<Cliente>("usp_UpdateClientes", this.setParameters(oCliente),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCliente.Error = ex.Message;
            }
            return _oCliente;
        }
        private DynamicParameters setParameters(Cliente oCliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oCliente.ClienteId != 0) parameters.Add("@ClienteId", oCliente.ClienteId);
            parameters.Add("@ClienteNombre", oCliente.ClienteNombre);
            parameters.Add("@Correo", oCliente.Correo);
            parameters.Add("@Clave", oCliente.Clave);
            parameters.Add("@Fecha_Registro", oCliente.Fecha_Registro);
            return parameters;
        }
    }
}
