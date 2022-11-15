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
    public class DepartamentoService : IDepartamentoService
    {
        Departamento _oDepartamento = new Departamento();
        List<Departamento> _oDepartamentos = new List<Departamento>();
        public Departamento Add(Departamento oDepartamento)
        {
            _oDepartamento = new Departamento();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oDepartamentos = con.Query<Departamento>("usp_InsertDepartamento", this.setParameters(oDepartamento),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oDepartamento.Error = ex.Message;
            }
            return _oDepartamento;
        }
        public string Delete(int IdDepartamento)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@DepartamentoId", IdDepartamento);
                        con.Query("usp_DeleteDepartamento", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oDepartamento.Error = ex.Message;
            }
            return _oDepartamento.Error;
        }
        public Departamento Get(int IdDepartamento)
        {
            _oDepartamento = new Departamento();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@DepartamentoId", IdDepartamento); var oDepartamento = con.Query<Departamento>("usp_SelectDepartamento", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oDepartamento != null && oDepartamento.Count() > 0)
                    {
                        _oDepartamento = oDepartamento.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oDepartamento.Error = ex.Message;
            }
            return _oDepartamento;
        }
        public List<Departamento> Gets()
        {
            _oDepartamentos = new List<Departamento>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oDepartamentos = con.Query<Departamento>("usp_SelectDepartamentoAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oDepartamentos != null && oDepartamentos.Count() > 0)
                    {
                        _oDepartamentos = oDepartamentos;
                    }
                }
            }
            catch (Exception ex)
            {
                _oDepartamento.Error = ex.Message;
            }
            return _oDepartamentos;
        }
        public Departamento Update(Departamento oDepartamento)
        {
            _oDepartamento = new Departamento();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oDepartamentos = con.Query<Departamento>("usp_UpdateDepartamento", this.setParameters(oDepartamento),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oDepartamento.Error = ex.Message;
            }
            return _oDepartamento;
        }
        private DynamicParameters setParameters(Departamento oDepartamento)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oDepartamento.DepartamentoId != 0) parameters.Add("@DepartamentoId", oDepartamento.DepartamentoId);
            parameters.Add("@DepartamentoNombre", oDepartamento.DepartamentoNombre);
            return parameters;
        }
    }
}
