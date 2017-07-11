using   System;
using System.Data.SqlClient;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System.Collections.Generic;

namespace ProjetoAssistencial.Repositorio
{

    public class AcaoRepositorio: IAcaoRepositorio
    {

        private string stringConexao;

        public AcaoRepositorio(string strConexao)
        {
            stringConexao = strConexao; // @" ";
        }

        public Guid Alterar(Acao Acao)
        {
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (SqlTransaction trans = conexao.BeginTransaction())
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand();

                        comando.Connection = conexao;

                        comando.Transaction = trans;

                        comando.CommandText = "UPDATE Acao SET Descricao = @Descricao, IdCategoria = @IdCategoria, IdEntidade = @IdEntidade WHERE Id = @Id ";

                        comando.Parameters.AddWithValue("Id", Acao.Id);
                        comando.Parameters.AddWithValue("Descricao", Acao.Descricao);
                        comando.Parameters.AddWithValue("IdCategoria", Acao.Categoria.Id);
                        comando.Parameters.AddWithValue("IdEntidade", Acao.Entidade.Id);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }

            }
            return Acao.Id;
        }

        public void Excluir(Guid id)
        {
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (SqlTransaction trans = conexao.BeginTransaction())
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand();

                        comando.Connection = conexao;

                        comando.Transaction = trans;

                        comando.CommandText = "DELETE FROM Acao WHERE Id = @Id ";

                        comando.Parameters.AddWithValue("Id", id);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
        }

        public Guid Inserir(Acao Acao)
        {
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();
                using (SqlTransaction trans = conexao.BeginTransaction())
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand();
                        comando.Connection = conexao;
                        comando.Transaction = trans;

                        comando.CommandText = "INSERT INTO Acao (Id, Descricao, IdCategoria, IdEntidade) VALUES(@Id, @Descricao, @IdCategoria, @IdEntidade)";

                        comando.Parameters.AddWithValue("Id", Acao.Id);
                        comando.Parameters.AddWithValue("Descricao", Acao.Descricao);
                        comando.Parameters.AddWithValue("IdCategoria", Acao.Categoria.Id);
                        comando.Parameters.AddWithValue("IdEntidade", Acao.Entidade.Id);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return Acao.Id;
        }

        public Acao Selecionar(Guid id)
        {
            Acao acao = null;

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao, IdCategoria, IdEntidade FROM Acao WHERE id = @id";

                comando.Parameters.AddWithValue("id", id);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    acao = new Acao()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString(),
                        Categoria = (new CategoriaRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdCategoria"].ToString()))),
                        Entidade = (new EntidadeRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdEntidade"].ToString())))
                    };
                }
            }
            return acao;
        }

        public List<Acao> SelecionarTodos()
        {
            List<Acao> listaAcoes = new List<Acao>();

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao, IdCategoria, IdEntidade FROM Acao";

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Acao Acao = new Acao()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString(),
                        Categoria = (new CategoriaRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdCategoria"].ToString()))),
                        Entidade = (new EntidadeRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdEntidade"].ToString())))
                    };

                    listaAcoes.Add(Acao);
                }
            }

            return listaAcoes;
        }

    }

}
