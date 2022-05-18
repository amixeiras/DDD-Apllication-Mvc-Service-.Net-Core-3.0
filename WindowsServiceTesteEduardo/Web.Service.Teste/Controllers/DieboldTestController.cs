using Domain.Service.Test.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Web.Service.Teste.Controllers
{
    public class DieboldTestController : Controller
    {
        private IControleWinServices controleWinServices;
        public DieboldTestController(IControleWinServices services) => controleWinServices = services;
        public IActionResult Index()
        {
            var obj = controleWinServices.GetControleWinServices();
            obj.ForEach(item => 
            {
                item.DtUltimaExecucao = Convert.ToDateTime(item.DtUltimaExecucao).ToString("dd/MM/yyyy HH:mm:ss");
            });
            return View(obj);
        }
    }
}
