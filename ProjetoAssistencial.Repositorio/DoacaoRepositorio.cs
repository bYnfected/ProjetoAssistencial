using   System;
using System.Data.SqlClient;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System.Collections.Generic;

namespace ProjetoAssistencial.Repositorio
{

    public class DoacaoRepositorio: IDoacaoRepositorio
    {

        private string stringConexao;

        public DoacaoRepositorio(string strConexao)
        {
            stringConexao = strConexao; // @" ";
        }

        public Guid Alterar(Doacao doacao)
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

                        comando.CommandText = "UPDATE Doacao SET Descricao = @Descricao, IdCategoria = @IdCategoria WHERE Id = @Id ";

                        comando.Parameters.AddWithValue("Id", doacao.Id);
                        comando.Parameters.AddWithValue("Descricao", doacao.Descricao);
                        comando.Parameters.AddWithValue("IdCategoria", doacao.Categoria.Id);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }

            }
            return doacao.Id;
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

                        comando.CommandText = "DELETE FROM Doacao WHERE Id = @Id ";

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

        public Guid Inserir(Doacao doacao)
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

                        comando.CommandText = "INSERT INTO Doacao (Id, Descricao, IdCategoria) VALUES(@Id, @Descricao, @IdCategoria)";

                        comando.Parameters.AddWithValue("Id", doacao.Id);
                        comando.Parameters.AddWithValue("Descricao", doacao.Descricao);
                        comando.Parameters.AddWithValue("IdCategoria", doacao.Categoria.Id);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return doacao.Id;
        }

        public Doacao Selecionar(Guid id)
        {
            Doacao doacao = null;

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao, IdCategoria, IdEntidade FROM Categoria WHERE id = @id";

                comando.Parameters.AddWithValue("id", id);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    doacao = new Doacao()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString(),
                        Categoria = (new CategoriaRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdCategoria"].ToString()))),
                        Entidade = (new EntidadeRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdEntidade"].ToString())))
                    };
                }
            }
            return doacao;
        }

        public List<Doacao> SelecionarTodos()
        {
            List<Doacao> listaDoacoes = new List<Doacao>();

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao, IdCategoria, IdEntidade FROM Doacao";

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Doacao doacao = new Doacao()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString(),
                        Categoria = (new CategoriaRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdCategoria"].ToString()))),
                        Entidade = (new EntidadeRepositorio(stringConexao).Selecionar(Guid.Parse(leitor["IdEntidade"].ToString())))
                    };

                    listaDoacoes.Add(doacao);
                }
            }

            return listaDoacoes;
        }

    }

}
