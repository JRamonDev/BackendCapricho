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
    public class MunicipioService : IMunicipioService
    {
        Municipio _oMunicipio = new Municipio();
        List<Municipio> _oMunicipios = new List<Municipio>();
        public Municipio Add(Municipio oMunicipio)
        {
            _oMunicipio = new Municipio();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oMunicipios = con.Query<Municipio>("usp_InsertMunicipio", this.setParameters(oMunicipio),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipio.Error = ex.Message;
            }
            return _oMunicipio;
        }
        public string Delete(int IdMunicipio)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@MunicipioId", IdMunicipio);
                        con.Query("usp_DeleteMunicipio", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipio.Error = ex.Message;
            }
            return _oMunicipio.Error;
        }
        public Municipio Get(int IdMunicipio)
        {
            _oMunicipio = new Municipio();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@MunicipioId", IdMunicipio); var oMunicipio = con.Query<Municipio>("usp_SelectMunicipio", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oMunicipio != null && oMunicipio.Count() > 0)
                    {
                        _oMunicipio = oMunicipio.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipio.Error = ex.Message;
            }
            return _oMunicipio;
        }
        public List<Municipio> Gets()
        {
            _oMunicipios = new List<Municipio>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oMunicipios = con.Query<Municipio>("usp_SelectMunicipioAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oMunicipios != null && oMunicipios.Count() > 0)
                    {
                        _oMunicipios = oMunicipios;
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipio.Error = ex.Message;
            }
            return _oMunicipios;
        }
        public Municipio Update(Municipio oMunicipio)
        {
            _oMunicipio = new Municipio();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oMunicipios = con.Query<Municipio>("usp_UpdateMunicipio", this.setParameters(oMunicipio),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oMunicipio.Error = ex.Message;
            }
            return _oMunicipio;
        }
        private DynamicParameters setParameters(Municipio oMunicipio)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oMunicipio.MunicipioId != 0) parameters.Add("@MunicipioId", oMunicipio.MunicipioId);
            parameters.Add("@MunicipioNombre", oMunicipio.MunicipioNombre);
            parameters.Add("@DepartamentoId", oMunicipio.DepartamentoId);
            return parameters;
        }
    }
}
