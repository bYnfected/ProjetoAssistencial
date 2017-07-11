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
    public class EntidadeController : Controller
    {
        // GET: Entidade
        public ActionResult Index()
        {
            //List<Doacao> Doacoes = MockFactory.MockFactory.GerarListaDoacoes(10);

            //ViewBag.Doacoes = Doacoes;

            List<Acao> Acoes = MockFactory.MockFactory.GerarListaAcoes(10);

            ViewBag.Acoes = Acoes;

            return View();
        }

        [HttpPost]
        public ActionResult GravarAcao(Acao Acao)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IAcaoRepositorio repositorio = new AcaoRepositorio(strconexao);
            AcaoAplicacao aplicacao = new AcaoAplicacao(repositorio);

            var acao = new AcaoDTO()
            {
                Id = Acao.Id,
                Categoria = CategoriaModelParaDTO(Acao.Categoria),
                Descricao = Acao.Descricao
            };

            aplicacao.Inserir(doacao);

            return RedirectToAction("Index", "Voluntario");

            return RedirectToAction("Index", "Entidade");
        }

        public ActionResult Acao()
        {
            return View("Acao");
        }

        [NonAction]
        public static CategoriaDTO CategoriaModelParaDTO(Categoria categoria)
        {
            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };
        }

    }
}