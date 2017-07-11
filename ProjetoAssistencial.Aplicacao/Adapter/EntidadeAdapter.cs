using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class EntidadeAdapter
    {
        public static Entidade ParaDomain(EntidadeDTO entidade)
        {
            return new Entidade()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Cidade = entidade.Cidade,
                Liberado = entidade.Liberado,
                Categorias = CategoriaAdapter.ListParaDomain(entidade.Categorias)
            };
        }

        public static EntidadeDTO ParaDTO(Entidade entidade)
        {
            return new EntidadeDTO()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Cidade = entidade.Cidade,
                Liberado = entidade.Liberado,
                Categorias = CategoriaAdapter.ListParaDTO(entidade.Categorias)
            };
        }

        public static List<Entidade> ListParaDomain(List<EntidadeDTO> listaEntidadeDTO)
        {
            List<Entidade> listaEntidade = new List<Entidade>();

            foreach(EntidadeDTO item in listaEntidadeDTO)
            {
                listaEntidade.Add(EntidadeAdapter.ParaDomain(item));
            }

            return listaEntidade;
        }

        public static List<EntidadeDTO> ListParaDTO(List<Entidade> listaEntidade)
        {
            List<EntidadeDTO> listaEntidadeDTO = new List<EntidadeDTO>();

            foreach(Entidade item in listaEntidade)
            {
                listaEntidadeDTO.Add(EntidadeAdapter.ParaDTO(item));
            }

            return listaEntidadeDTO;
        }
    }
}
