using System;
using System.Data.SqlClient;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System.Collections.Generic;

namespace ProjetoAssistencial.Repositorio
{

    public class EntidadeRepositorio : IEntidadeRepositorio
    {
        private string stringConexao;

        public EntidadeRepositorio(string strConexao)
        {
            stringConexao = strConexao; // @" ";
        }

        public Guid Alterar(Entidade categoria)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Inserir(Entidade categoria)
        {
            throw new NotImplementedException();
        }

        public Entidade Selecionar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Entidade> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }

}
