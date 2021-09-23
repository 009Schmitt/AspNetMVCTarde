using BAL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SiteDaTarde.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SiteDaTarde.Controllers
{
    public class HomeController : Controller
    {
        private Response res;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            res = new Response();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Pagina()
        {
            ViewData["Nome"] = "Jorge";
            ViewData["Idade"] = "35";
            ViewBag.Cpf = "78945515578";
            ViewBag.Rg = "7851552";

            Cachorro doginho = new Cachorro
            {
                Nome = "Scooby-Doo",
                NomeDoDono = "Salsicha",
                Idade = 7,
                IsDocil = true
            };


            return View(doginho);
        }

        [HttpPost]
        public IActionResult AuthLogin(string user, string password)
        {
            if (user == "Admin" && password == "Juquinha")
            {
                return RedirectToAction("LoginEfetuado", "Home");
            }
            else
            {
                return RedirectToAction("Pagina", "Home");
            }
        }

        public IActionResult LoginEfetuado()
        {
            return View();
        }

        public IActionResult CadastroUsuario()
        {
            //Response res = new Response { ErrorMessage = " "};
            return View(res);
        }

        [HttpPost]
        public IActionResult AuthCadastro(string nomeUsuario, string senha)
        {
            Usuario user = new Usuario
            {
                NomeDeUsuario = nomeUsuario,
                Senha = senha
            };
            res = UsuarioBAL.Insert(user);
            if (res.Executed)
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                //ViewData["ErrorLog"] = res.ErrorMessage;
                //ViewBag.Error = res.ErrorMessage;
                return RedirectToAction("CadastroUsuario", "Home");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
