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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult GravarPrimeiroAcessoEntidade(Entidade Entidade)
        //{
        //    string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        //    IEntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
        //    EntidadeAplicacao aplicacao = new EntidadeAplicacao();

        //    var entidade = new EntidadeDTO()
        //    {
        //        Id = Entidade.Id,
        //        Nome = Entidade.Nome,
        //        Cidade = Entidade.Cidade,
        //        Liberado = false,
        //        Usuario = Entidade.Usuario,
        //        Senha = Entidade.Senha
        //    };

        //    aplicacao.Inserir(entidade);

        //    return RedirectToAction("Index", "Entidade");
        //}

        //[HttpPost]
        //public ActionResult GravarPrimeiroAcessoVoluntario(Voluntario Voluntario)
        //{
        //    string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        //    EntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
        //    VoluntarioAplicacao aplicacao = new VoluntarioAplicacao();

        //    var voluntario = new VoluntarioDTO()
        //    {
        //        Id = Voluntario.Id,
        //        Nome = Voluntario.Nome,
        //        Cidade = Voluntario.Cidade,
        //        Usuario = Voluntario.Usuario,
        //        Senha = Voluntario.Senha
        //    };

        //    aplicacao.Inserir(voluntario);

        //    return RedirectToAction("Index", "Voluntario");
        //}


        public ActionResult ErroLogin()
        {
            return View();
        }

        public ActionResult PrimeiroAcessoEntidade(Entidade Entidade)
        {
            return View();
        }

        
        public ActionResult PrimeiroAcessoVoluntario(Voluntario Voluntario)
        {
            return View();
        }

        public ActionResult Autenticar(string usuario, string senha, string tipo)
        {
            Session["tipoUsuario"] = tipo;

            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();


            //EntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
            //VoluntarioAplicacao aplicacao = new VoluntarioAplicacao();

            //switch (tipo)
            //{
            //    case "entidade":

            //        return RedirectToAction("Index", "Entidade");

            //        break;

            //    case "voluntario":

            //        return RedirectToAction("Index", "Voluntario");

            //        break;

            //    default:

            //        return RedirectToAction("ErroLogin", "Login");

            //        break;
            //}

            return RedirectToAction("ErroLogin", "Login");


        }
    }
}