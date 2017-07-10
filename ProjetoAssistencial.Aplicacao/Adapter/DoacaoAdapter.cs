using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class DoacaoAdapter
    {

        public static Doacao ParaDomain(DoacaoDTO doacao)
        {
            return new Doacao()
            {
                Id = doacao.Id,
                Descricao = doacao.Descricao,
                Entidade = EntidadeAdapter.ParaDomain(doacao.Entidade),
                Categoria = CategoriaAdapter.ParaDomain(doacao.Categoria)
            };
        }

        public static DoacaoDTO ParaDTO(Doacao doacao)
        {
            return new DoacaoDTO()
            {
                Id = doacao.Id,
                Descricao = doacao.Descricao,
                Entidade = EntidadeAdapter.ParaDTO(doacao.Entidade),
                Categoria = CategoriaAdapter.ParaDTO(doacao.Categoria)
            };
        }

    }
}
