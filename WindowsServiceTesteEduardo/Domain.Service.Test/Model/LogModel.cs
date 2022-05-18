using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.Test.Model
{
    /// <summary>
    /// Classe modelo de Log
    /// </summary>
    public class LogModel
    {
        /// <summary>
        /// Nome da Classe
        /// </summary>
        public string Classe { get; set; }
        /// <summary>
        /// Nome do Método
        /// </summary>
        public string Metodo { get; set; }
        /// <summary>
        /// Descrição do erro.
        /// </summary>
        public string Erro { get; set; }
    }
}
