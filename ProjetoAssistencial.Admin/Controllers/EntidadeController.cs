using ProjetoAssistencial.Admin.Models;
using ProjetoAssistencial.Aplicacao;
using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Repositorio;
using ProjetoAssistencial.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IEntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
            EntidadeAplicacao aplicacao = new EntidadeAplicacao(repositorio);

            List<EntidadeDTO> entidades = aplicacao.SelecionarTodos();

            if (entidades != null)
            {
                ViewBag.Entidades = entidades;
            }
            
            return View();
        }

        public ActionResult Liberar(Guid Id)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IEntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
            EntidadeAplicacao aplicacao = new EntidadeAplicacao(repositorio);

            EntidadeDTO entidade = aplicacao.Procurar(Id);

            if (entidade != null)
            { 
                entidade.Liberado = true;

                aplicacao.Alterar(entidade);
            }

            return View("Index");
        }

        public ActionResult Proibir(Guid Id)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            List<CategoriaDTO> categorias = aplicacao.SelecionarTodos();

            return View("Index");
        }
    }
}