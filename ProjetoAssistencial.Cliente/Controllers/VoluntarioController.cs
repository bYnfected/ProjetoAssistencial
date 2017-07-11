using ProjetoAssistencial.Aplicacao;
using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Cliente.Models;
using ProjetoAssistencial.Dominio.Repositorio;
using ProjetoAssistencial.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoAssistencial.Cliente.Controllers
{
    public class VoluntarioController : Controller
    {
        // GET: Voluntario
        public ActionResult Index()
        {
            List<Acao> Acoes = MockFactory.MockFactory.GerarListaAcoes(10);

            ViewBag.Acoes = Acoes;

            List<Doacao> Doacoes = MockFactory.MockFactory.GerarListaDoacoes(10);

            ViewBag.Doacoes = Doacoes;

            return View();
        }

        //[HttpPost]
        //public ActionResult GravarDoacao(Doacao Doacao)
        //{
        //    string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        //    IDoacaoRepositorio repositorio = new DoacaoRepositorio(strconexao);
        //    DoacaoAplicacao aplicacao = new DoacaoAplicacao(repositorio);

        //    var daocao = new DoacaoDTO()
        //    {
        //        Id = Doacao.Id,
        //        Voluntario = Entidade.Cidade,
        //        Descricao = Doacao.Descricao
        //    };

        //    aplicacao.Inserir(entidade);

        //    return RedirectToAction("Index", "Voluntario");
        //}

        public ActionResult Doar()
        {
            return View("Doar");
        }

        public ActionResult AceitarAcao()
        {

            return null;
            //return View("Doar");
        }

    }
}