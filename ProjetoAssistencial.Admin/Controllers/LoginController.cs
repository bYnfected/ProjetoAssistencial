using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string usuario, string senha)
        {
            if (usuario.ToUpper() == "ADMIN" && senha.ToUpper() == "123456")
                return RedirectToAction("Index", "Default");
            else
                return RedirectToAction("ErroLogin", "Login");
        }

        public ActionResult ErroLogin()
        {
            return View();
        }

    }
}