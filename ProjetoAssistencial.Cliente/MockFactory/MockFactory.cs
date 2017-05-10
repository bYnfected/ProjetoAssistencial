using ProjetoAssistencial.Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.MockFactory
{
    public class MockFactory
    {
        public static List<Acao> GerarListaAcoes(int qtd)
        {
            List<Acao> acoes = new List<Acao>();

            for (int i = 0; i < qtd; i++)
            {
                acoes.Add(new Acao()
                {
                    Id = Guid.NewGuid(),
                    IdEntidade = Guid.NewGuid(),
                    IdCategoria = Guid.NewGuid(),
                    Voluntarios = new List<Voluntario>(),
                    Descricao = "Descricao da Ação",
                    DataHora = DateTime.Now
            
                });
            }
            return acoes;
        }

        public static List<Doacao> GerarListaDoacoes(int qtd)
        {
            List<Doacao> doacoes = new List<Doacao>();

            for(int i = 0; i< qtd; i++)
            {
                doacoes.Add(new Doacao()
                {
                    IdVoluntario = Guid.NewGuid(),
                    IdEntidade = Guid.NewGuid(),
                    Descricao = "Descricao doacao"
                });
            }
                return doacoes;
        }
    }
}