using Dapper;
using Domain.Service.Test.Interface;
using Domain.Service.Test.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.Service.test.Data.Repository
{
    public class ControleWinServicesRepository : BaseRepository, IControleWinServices, IDisposable
    {
        public ControleWinServicesRepository(ILogArquivo log) => _log = log;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Busca a Lista de execuções do serviço
        /// </summary>
        /// <param name="id">Id da execução (Opcional)</param>
        /// <returns>Lista de execuções</returns>
        public List<ControleWinServicesModel> GetControleWinServices(Int64? id = null)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString: ConnectionString))
                {
                    var query = "exec [dbo].[sp_busca_controlewindowsservices] @ID";

                    return conn.Query<ControleWinServicesModel>(query, new { ID = id }).ToList();
                }
            }
            catch (SqlException ex)
            {
                _log.IncluirLog(new LogModel
                {
                    Erro = ex.GetBaseException().Message,
                    Metodo = nameof(GetControleWinServices)
                });
                throw new Exception("Erro ao buscar dados", ex);
            }
            catch (Exception ex)
            {
                _log.IncluirLog(new LogModel
                {
                    Erro = ex.GetBaseException().Message,
                    Metodo = nameof(GetControleWinServices)
                });
                throw new Exception("Erro ao buscar dados", ex);
            }
        }
        /// <summary>
        /// Incluir Execuções
        /// </summary>
        /// <param name="controleWinServicesModel"></param>
        public void IncluirExecucao(ControleWinServicesModel controleWinServicesModel)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString: ConnectionString))
                {
                    var query = "exec [dbo].[sp_inclui_controlewindowsservices] @NMSERVICO, @NMMAQUINA, @DTULTIMAEXECUCAO";

                    conn.Execute(query, controleWinServicesModel);
                }
            }
            catch (SqlException ex)
            {
                _log.IncluirLog(new LogModel
                {
                    Erro = ex.GetBaseException().Message,
                    Metodo = nameof(GetControleWinServices)
                });
                throw new Exception("Erro ao incluir dados", ex);
            }
            catch (Exception ex)
            {
                _log.IncluirLog(new LogModel
                {
                    Erro = ex.GetBaseException().Message,
                    Metodo = nameof(GetControleWinServices)
                });
                throw new Exception("Erro ao incluir dados", ex);
            }
        }
    }
}
