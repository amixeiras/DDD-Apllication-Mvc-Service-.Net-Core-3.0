using Domain.Service.Test.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Test.Interface
{
    public interface ILogArquivo
    {
        /// <summary>
        /// Incluir log em arquivo local
        /// </summary>
        /// <param name="logModel">Dados do Log</param>
        void IncluirLog(LogModel logModel);
    }
}
