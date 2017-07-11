using System;
using System.Data.SqlClient;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System.Collections.Generic;

namespace ProjetoAssistencial.Repositorio
{

    public class CategoriaRepositorio: ICategoriaRepositorio
    {

        private string stringConexao;

        public CategoriaRepositorio(string strConexao)
        {
            stringConexao = strConexao; 
        }

        public Guid Alterar(Categoria categoria)
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

                        comando.CommandText = "UPDATE Categoria SET  Descricao = @Descricao WHERE Id = @Id ";

                        comando.Parameters.AddWithValue("Id", categoria.Id);
                        comando.Parameters.AddWithValue("Descricao", categoria.Descricao);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }

            }
            return categoria.Id;
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

                        comando.CommandText = "DELETE FROM Categoria WHERE Id = @Id ";

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

        public Guid Inserir(Categoria categoria)
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

                        comando.CommandText = "INSERT INTO Categoria (Id, Descricao) VALUES(@Id, @Descricao)";

                        comando.Parameters.AddWithValue("Id", categoria .Id);
                        comando.Parameters.AddWithValue("Descricao", categoria.Descricao);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return categoria.Id;
        }

        public Categoria Selecionar(Guid id)
        {
            Categoria categoria = null;

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao FROM Categoria WHERE id = @id";

                comando.Parameters.AddWithValue("id", id);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    categoria = new Categoria()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString()
                    };
                }
            }
            return categoria;
        }

        public List<Categoria> SelecionarTodos()
        {
            List<Categoria> listaCategorias = new List<Categoria>();

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "SELECT Id, Descricao FROM Categoria";

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Categoria categoria = new Categoria()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Descricao = leitor["Descricao"].ToString()
                    };

                    listaCategorias.Add(categoria);
                }
            }

            return listaCategorias;
        }

    }

}
