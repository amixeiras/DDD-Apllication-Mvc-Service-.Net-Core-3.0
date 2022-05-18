using Domain.Service.Test.Model;
using System;
using System.Collections.Generic;

namespace Domain.Service.Test.Interface
{
    public interface IControleWinServices
    {
        /// <summary>
        /// Busca a Lista de execuções do serviço
        /// </summary>
        /// <param name="id">Id da execução (Opcional)</param>
        /// <returns>Lista de execuções</returns>
        List<ControleWinServicesModel> GetControleWinServices(Int64? id = null);
        /// <summary>
        /// Incluir Execuções
        /// </summary>
        /// <param name="controleWinServicesModel"></param>
        void IncluirExecucao(ControleWinServicesModel controleWinServicesModel);
    }
}
