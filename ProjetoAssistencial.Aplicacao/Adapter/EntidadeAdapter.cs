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
    }
}
