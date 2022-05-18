using Domain.Service.Test.Helper;
using Domain.Service.Test.Interface;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Timers;

namespace AppServiceTest
{
    /// <summary>
    /// Classe de execução do serviço
    /// </summary>
    internal class ServiceApp
    {
        IControleWinServices controleWinServices;
        Timer _timer;
        EventLog eventLog;
        public ServiceApp(IControleWinServices _controleWinServices)
        {
            //Configuração do event log do windows
            eventLog = new System.Diagnostics.EventLog();
            eventLog.Source = "WindowsServiceTesteEduardo";
            eventLog.Log = "WindowsServiceTesteEduardolog";
            //Injeção de dependencia
            controleWinServices = _controleWinServices;
            //Inicialização do timer
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Execute();
        }
        public void Start()
        {
            _timer.Start();
            eventLog.WriteEntry("Serviço 'Windows Service Teste - Eduardo' iniciado com sucesso !", EventLogEntryType.Information);
        }
        public void Stop()
        {
            _timer.Stop();
            eventLog.WriteEntry("Serviço 'Windows Service Teste - Eduardo' parado com sucesso !", EventLogEntryType.Information);
        }

        private void Execute()
        {
            _timer.Stop();
            eventLog.WriteEntry("Serviço 'Windows Service Teste - Eduardo' inciando execução!", EventLogEntryType.Information);
            try
            {
                //Get service name
                string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                //Get Machine name
                string currentMachineName = Environment.MachineName;

                controleWinServices.IncluirExecucao(new Domain.Service.Test.Model.ControleWinServicesModel
                {
                    NmServico = processName,
                    NmMaquina = currentMachineName,
                    DtUltimaExecucao = DateTime.UtcNow.ToString("s")
                });
            }
            catch (Exception ex)
            {
                eventLog.WriteEntry($@"Erro ao executar o Serviço 'Windows Service Teste - Eduardo' 
                    Tipo do Erro: {ex.GetType().Name}
                    Descrição do Erro: {ex.GetBaseException().Message}
                    ", EventLogEntryType.Error);
            }
            _timer.Start();
            eventLog.WriteEntry("Serviço 'Windows Service Teste - Eduardo' fim da execução!", EventLogEntryType.Information);
        }
    }
}
