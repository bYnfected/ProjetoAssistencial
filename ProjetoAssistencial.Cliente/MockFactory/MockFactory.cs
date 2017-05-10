using ProjetoAssistencial.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.MockFactory
{
    public class MockFactory
    {
        public static List<Acao> GerarListaCategorias(int qtd)
        {
            List<Acao> acoes = new List<Acao>();

            for (int i = 0; i < qtd; i++)
            {
                acoes.Add(new Acao()
                {
                    Id = Guid.NewGuid(),
                    IdEntidade = Guid.NewGuid(),
                    IdCategoria = Guid.NewGuid(),
                    Voluntarios = new List<Voluntario>,
                    Descricao = "Descricao da Ação",
                    DataHora = DateTime.Now
            
                });
            }
            return acoes;
        }
    }
}