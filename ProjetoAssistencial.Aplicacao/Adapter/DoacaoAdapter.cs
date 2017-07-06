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
                Entidade = doacao.Entidade,
                Categoria = doacao.Categoria
            };
        }

        public static DoacaoDTO ParaDto(Doacao doacao)
        {
            return new DoacaoDTO()
            {
                Id = doacao.Id,
                Descricao = doacao.Descricao,
                Entidade = doacao.Entidade,
                Categoria = doacao.Categoria
            };
        }

    }
}
