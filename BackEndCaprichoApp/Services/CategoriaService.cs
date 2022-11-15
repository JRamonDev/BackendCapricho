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
    public class CategoriaService:ICategoriaService
    {
        Categoria _oCategoria = new Categoria();
        List<Categoria> _oCategorias = new List<Categoria>();
        public Categoria Add(Categoria oCategoria)
        {
            _oCategoria = new Categoria();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        var oCategorias = con.Query<Categoria>("usp_InsertCategoria", this.setParameters(oCategoria),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCategoria.Error = ex.Message;
            }
            return _oCategoria;
        }
        public string Delete(int IdCategoria)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                        var param = new DynamicParameters();

                        param.Add("@CategoriaId", IdCategoria);
                        con.Query("usp_DeleteCategoria", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCategoria.Error = ex.Message;
            }
            return _oCategoria.Error;
        }
        public Categoria Get(int IdCategoria)
        {
            _oCategoria = new Categoria();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var param = new DynamicParameters();
                    param.Add("@CategoriaId", IdCategoria); var oCategoria = con.Query<Categoria>("usp_SelectCategoria", param,
                    commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oCategoria != null && oCategoria.Count() > 0)
                    {
                        _oCategoria = oCategoria.SingleOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                _oCategoria.Error = ex.Message;
            }
            return _oCategoria;
        }
        public List<Categoria> Gets()
        {
            _oCategorias = new List<Categoria>();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                    var oCategorias = con.Query<Categoria>("usp_SelectCategoriaAll", commandType:

                    CommandType.StoredProcedure).ToList();
                    if (oCategorias != null && oCategorias.Count() > 0)
                    {
                        _oCategorias = oCategorias;
                    }
                }
            }
            catch (Exception ex)
            {
                _oCategoria.Error = ex.Message;
            }
            return _oCategorias;
        }
        public Categoria Update(Categoria oCategoria)
        {
            _oCategoria = new Categoria();
            try
            {
                using (IDbConnection con = new SqlConnection(Global.ConnectionString))
                {
                    if (con.State == ConnectionState.Closed)

                    {
                        con.Open();
                        var oCategorias = con.Query<Categoria>("usp_UpdateCategoria", this.setParameters(oCategoria),
                        commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                _oCategoria.Error = ex.Message;
            }
            return _oCategoria;
        }
        private DynamicParameters setParameters(Categoria oCategoria)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (oCategoria.CategoriaId != 0) parameters.Add("@CategoriaId", oCategoria.CategoriaId);
            parameters.Add("@CategoriaNombre", oCategoria.CategoriaNombre);
            return parameters;
        }
    }
}
