using ProjetoAssistencial.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAssistencial.Dominio.Entidade;
using System.Data.SqlClient;

namespace ProjetoAssistencial.Repositorio
{
    public class VoluntarioRepositorio : IVoluntarioRepositorio
    {
        private string stringConexao;

        public VoluntarioRepositorio(string strConexao)
        {
            stringConexao = strConexao;
        }
        public Guid Alterar(Voluntario voluntario)
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
                        // Alterar comando SQL, verificar como fica categorias.
                        comando.CommandText = "UPDATE Voluntario SET Nome = @Nome, Cidade = @Cidade,  WHERE Id = @Id";

                        comando.Parameters.AddWithValue("Id", voluntario.Id);

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
                        // Deletar também a lista de categorias na tabela VoluntarioCategoria?
                        comando.CommandText = "DELETE FROM Voluntario WHERE Id = @Id ";

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

        public Guid Inserir(Voluntario voluntario)
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
                        // Verificar como fica a lista de categorias
                        comando.CommandText = "INSERT INTO Voluntario (Id, Cidade, Usuario, Senha) VALUES(@Id, @Cidade, @Usuario, @Senha)";

                        comando.Parameters.AddWithValue("Id", voluntario.Id);
                        comando.Parameters.AddWithValue("Cidade", voluntario.Cidade);
                        comando.Parameters.AddWithValue("Usuario", voluntario.Usuario);
                        comando.Parameters.AddWithValue("Senha", voluntario.Senha);

                        comando.ExecuteNonQuery();

                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return voluntario.Id;
        }

        public Voluntario Selecionar(Guid id)
        {
            Voluntario voluntario = null;

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;
                // Verificar lista de categorias
                comando.CommandText = "SELECT Id, Cidade, Usuario, Senha FROM Voluntario WHERE id = @id";

                comando.Parameters.AddWithValue("id", id);

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    voluntario = new Voluntario()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Cidade = leitor["Cidade"].ToString(),
                        Usuario = leitor["Usuario"].ToString(),
                        Senha = leitor["Senha"].ToString()
                    };
                }
            }
            return voluntario;
        }

        public List<Voluntario> SelecionarTodos()
        {
            List<Voluntario> listaVoluntarios = new List<Voluntario>();

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                SqlCommand comando = new SqlCommand();

                comando.Connection = conexao;
                // verificar lista categorias
                comando.CommandText = "SELECT Id, Cidade, Usuario, Senha FROM Voluntario";

                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Voluntario voluntario = new Voluntario()
                    {
                        Id = Guid.Parse(leitor["Id"].ToString()),
                        Cidade = leitor["Cidade"].ToString(),
                        Usuario = leitor["Usuario"].ToString(),
                        Senha = leitor["Senha"].ToString()
                    };

                    listaVoluntarios.Add(voluntario);
                }
            }

            return listaVoluntarios;
        }
    }
}
