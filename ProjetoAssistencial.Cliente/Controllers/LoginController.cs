using ProjetoAssistencial.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Cliente.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarPrimeiroAcessoEntidade(Entidade Entidade)
        {
            return RedirectToAction("Index", "Entidade");
        }

        [HttpPost]
        public ActionResult GravarPrimeiroAcessoVoluntario(Voluntario Voluntario)
        {
            return RedirectToAction("Index", "Voluntario");
        }

        
        public ActionResult PrimeiroAcessoEntidade(Entidade Entidade)
        {
            return View();
        }

        
        public ActionResult PrimeiroAcessoVoluntario(Voluntario Voluntario)
        {
            return View();
        }

        public ActionResult Autenticar()
        {
            return RedirectToAction("Index", "Default");
        }
    }
}