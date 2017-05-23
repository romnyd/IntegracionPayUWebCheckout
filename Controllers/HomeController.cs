using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsopagosPayU.Models;
using AsopagosPayU.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsopagosPayU.Controllers
{
    public class HomeController : Controller
    {
        private IServicioCliente _servicioCliente;

        public HomeController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }



        public IActionResult Index()
        {
            // Cliente c = new Cliente{
            //     ClienteEmail = "prueba@test.com",
            //     ClienteNombre = "felipe suarez",
            //     ClienteDireccionPrincipal = "calle 160 64-04",
            //     ClienteTelefono = "4753626"                
            // };
            // _servicioCliente.AgregarCliente(c);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
