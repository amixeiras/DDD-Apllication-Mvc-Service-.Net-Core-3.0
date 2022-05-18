using Domain.Service.Test.Interface;
using Domain.Service.Test.Model;
using Infra.Service.test.Data.Repository;
using System.Collections.Generic;

namespace Services.Service.Test.Implementations
{
    public class ControleWinServices : IControleWinServices
    {
        ILogArquivo _logArquivo;
        public ControleWinServices(ILogArquivo logArquivo)
        {
            _logArquivo = logArquivo;
        }

        public List<ControleWinServicesModel> GetControleWinServices(long? id = null)
        {
            using (var obj = new ControleWinServicesRepository(_logArquivo))
            {
                return obj.GetControleWinServices(id);
            }
        }

        public void IncluirExecucao(ControleWinServicesModel controleWinServicesModel)
        {
            using (var obj = new ControleWinServicesRepository(_logArquivo))
            {
                obj.IncluirExecucao(controleWinServicesModel);
            }
        }
    }
}
