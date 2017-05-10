using ProjetoAssistencial.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Admin.Controllers
{
    public class EntidadeController : Controller
    {
        // GET: Entidade
        public ActionResult Index()
        {
            List<Entidade> entidades = MockFacktory.MockFactory.GerarListaEntidade(10);

            ViewBag.Entidades = entidades;
            return View();
        }

        public ActionResult Autorizar()
        {
            return View("Index");
        }
    }
}