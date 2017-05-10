using ProjetoAssistencial.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Admin.MockFacktory
{
    public class MockFactory
    {
        public static List<Categoria> GerarListaCategorias (int qtd)
        {
            List<Categoria> categorias = new List<Categoria>();

            for(int i = 0; i< qtd; i++)
            {
                categorias.Add(new Categoria()
                {
                    Id = Guid.NewGuid(),
                    Descricao = "Descricao"
                });
            }
            return categorias;
        }

        public static List<Entidade> GerarListaEntidade (int qtd)
        {
            List<Entidade> entidades = new List<Entidade>();

            for(int i = 0; i<qtd; i++)
            {
                entidades.Add(new Entidade()
                {
                    Id = Guid.NewGuid(),
                    Nome = "Nome Entidade",
                    Liberado = false
                });
            }
            return entidades;
        }
    }
}