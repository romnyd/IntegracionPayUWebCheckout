using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopagosPayU.Models;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var hola = "hello world";
            var dbcontext = new Contexto();
            dbcontext.Add(new Aplicativo{
                AplicativoUrl = "www.asopagos2.com",
                AplicativoApiKey = "dsfa12344ad12"
            });
            dbcontext.SaveChanges();


            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
