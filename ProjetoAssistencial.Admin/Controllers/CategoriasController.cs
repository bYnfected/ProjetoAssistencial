using ProjetoAssistencial.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Admin.Controllers
{
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            List<Categoria> categorias = MockFacktory.MockFactory.GerarListaCategorias(10);

            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Cadastro()
        {

            return View();
        }

        public ActionResult Gravar()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Modificar(Guid Id)
        {

            return View();
        }
    }
}