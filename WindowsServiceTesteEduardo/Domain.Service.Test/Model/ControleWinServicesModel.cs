using System;

namespace Domain.Service.Test.Model
{
    /// <summary>
    /// Controle Windows Services
    /// </summary>
    public class ControleWinServicesModel : BaseModel
    {
        
        /// <summary>
        /// Nome do Serviço
        /// </summary>
        public string NmServico { get; set; }
        /// <summary>
        /// Nome da Máquina
        /// </summary>
        public string NmMaquina { get; set; }
        /// <summary>
        /// Data Ultima Execução
        /// </summary>
        public string DtUltimaExecucao { get; set; }

    }
}
