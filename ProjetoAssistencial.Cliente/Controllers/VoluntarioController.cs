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


            ////////////////////////////


            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IDoacaoRepositorio repositorio = new DoacaoRepositorio(strconexao);
            DoacaoAplicacao aplicacao = new DoacaoAplicacao(repositorio);

            List<DoacaoDTO> Doacoes = aplicacao.SelecionarTodos();

            ViewBag.Doacoes = Doacoes;

            return View();
        }

        [HttpPost]
        public ActionResult GravarDoacao(Doacao Doacao)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IDoacaoRepositorio repositorio = new DoacaoRepositorio(strconexao);
            DoacaoAplicacao aplicacao = new DoacaoAplicacao(repositorio);

            var doacao = new DoacaoDTO()
            {
                Id = Doacao.Id,
                Categoria = CategoriaModelParaDTO(Doacao.Categoria),
                Entidade = EntidadeModelParaDTO(Doacao.Entidade)
            };

            aplicacao.Inserir(doacao);

            return RedirectToAction("Index", "Voluntario");
        }

        public ActionResult Doar()
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            List<CategoriaDTO> categorias = aplicacao.SelecionarTodos();

            ViewBag.Categorias = categorias;

            return View("Doar");
        }

        public ActionResult AceitarAcao()
        {

            return null;
            //return View("Doar");
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

        [NonAction]
        public static EntidadeDTO EntidadeModelParaDTO(Entidade entidade)
        {
            return new EntidadeDTO()
            {
                Id = entidade.Id,
                Cidade = entidade.Cidade,
                Nome = entidade.Nome,
                Usuario = entidade.Usuario,
                Senha = entidade.Senha,
                Liberado = entidade.Liberado
            };
        }

    }
}