using ProjetoAssistencial.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Cliente.Controllers
{
    public class EntidadeController : Controller
    {
        // GET: Entidade
        public ActionResult Index()
        {
            List<Doacao> Doacoes = MockFactory.MockFactory.GerarListaDoacoes(10);

            ViewBag.Doacoes = Doacoes;

            List<Acao> Acoes = MockFactory.MockFactory.GerarListaAcoes(10);

            ViewBag.Acoes = Acoes;

            return View();
        }

        [HttpPost]
        public ActionResult GravarAcao()
        {
            return RedirectToAction("Index", "Entidade");
        }

        public ActionResult Acao()
        {
            return View("Acao");
        }

    }
}