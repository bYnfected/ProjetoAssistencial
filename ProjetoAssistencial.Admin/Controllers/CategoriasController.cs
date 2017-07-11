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
    public class CategoriasController : Controller
    {
        // GET: Categorias
        public ActionResult Index()
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            List<CategoriaDTO> categorias = aplicacao.SelecionarTodos();

            ViewBag.Categorias = categorias;

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Modificar(Guid Id)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            CategoriaDTO categoria = aplicacao.Procurar(Id);

            ViewBag.Categoria = categoria;

            return View();
        }

        public ActionResult Gravar(Categoria categoria)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            var cat = new CategoriaDTO()
            {
                Id = Guid.NewGuid(),
                Descricao = categoria.Descricao
            };

            aplicacao.Inserir(cat);

            return RedirectToAction("Index");
        }

        public ActionResult Alterar(Categoria categoria)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            ICategoriaRepositorio repositorio = new CategoriaRepositorio(strconexao);
            CategoriaAplicacao aplicacao = new CategoriaAplicacao(repositorio);

            var cat = new CategoriaDTO()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };

            aplicacao.Alterar(cat);

            return RedirectToAction("Index");
        }
    }
}