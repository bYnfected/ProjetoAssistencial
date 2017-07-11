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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GravarPrimeiroAcessoEntidade(Entidade Entidade)
        {
            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            IEntidadeRepositorio repositorio = new EntidadeRepositorio(strconexao);
            EntidadeAplicacao aplicacao = new EntidadeAplicacao(repositorio);

            var entidade = new EntidadeDTO()
            {
                Id = Entidade.Id,
                Nome = Entidade.Nome,
                Cidade = Entidade.Cidade,
                Liberado = false,
                Usuario = Entidade.Usuario,
                Senha = Entidade.Senha
            };

            aplicacao.Inserir(entidade);

            return RedirectToAction("Index", "Entidade");
        }

        //[HttpPost]
        //public ActionResult GravarPrimeiroAcessoVoluntario(Voluntario Voluntario)
        //{
        //    string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

        //    IVoluntarioRepositorio repositorio = new VoluntarioRepositorio(strconexao);
        //    EntidadeAplicacao aplicacao = new EntidadeAplicacao(repositorio);

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
            Session["idUsuario"] = null;

            string strconexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            
            switch (tipo)
            {
                case "entidade":
                    IEntidadeRepositorio repositorioEntidade = new EntidadeRepositorio(strconexao);
                    EntidadeAplicacao aplicacaoEntidade = new EntidadeAplicacao(repositorioEntidade);
                    EntidadeDTO entidade = aplicacaoEntidade.SelecionarTodos().Where(x => x.Usuario.ToUpper() == usuario.ToUpper()).FirstOrDefault();

                    if (entidade != null)
                    {
                        if (entidade.Senha.ToUpper() == senha.ToUpper())
                        {
                            Session["idUsuario"] = entidade.Id;
                            return RedirectToAction("Index", "Entidade");
                        }
                        else
                            return RedirectToAction("ErroLogin", "Login");
                    }
                    else
                        return RedirectToAction("ErroLogin", "Login");

                    break;

                case "voluntario":
                    IVoluntarioRepositorio repositorioVoluntario = new VoluntarioRepositorio(strconexao);
                    VoluntarioAplicacao aplicacaoVoluntario = new VoluntarioAplicacao(repositorioVoluntario);
                    VoluntarioDTO voluntario = aplicacaoVoluntario.SelecionarTodos().Where(x => x.Usuario.ToUpper() == usuario.ToUpper()).FirstOrDefault();

                    if (voluntario != null)
                    {
                        if (voluntario.Senha.ToUpper() == senha.ToUpper())
                        {
                            Session["idUsuario"] = voluntario.Id;
                            return RedirectToAction("Index", "Voluntario");
                        }
                        else
                            return RedirectToAction("ErroLogin", "Login");
                    }
                    else
                        return RedirectToAction("ErroLogin", "Login");


                    break;

                default:

                    return RedirectToAction("ErroLogin", "Login");

                    break;
            }
        }
    }
}