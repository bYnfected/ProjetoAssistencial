using System;
using System.Data.SqlClient;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System.Collections.Generic;

namespace ProjetoAssistencial.Repositorio
{

    public class AcaoVoluntarioRepositorio: IAcaoVoluntarioRepositorio
    {

        private string stringConexao;

        public AcaoVoluntarioRepositorio(string strConexao)
        {
            stringConexao = strConexao; // @" ";
        }

        public bool Inserir(AcaoVoluntario acaoVoluntario)
        {
            bool retorno = false;

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

                        comando.CommandText = "INSERT INTO AcaoVoluntario (IdAcao, IdVoluntario) VALUES(@IdAcao, @IdVoluntario)";

                        comando.Parameters.AddWithValue("IdAcao", acaoVoluntario.Voluntario.Id);
                        comando.Parameters.AddWithValue("IdVoluntario", acaoVoluntario.Acao.Id);

                        comando.ExecuteNonQuery();

                        trans.Commit();

                        retorno = true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                    }
                }
            }
            return retorno;
        }

    }

}
