using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    class AcaoAdapter
    {
        public static Acao ParaDomain(AcaoDTO acao)
        {
            return new Acao()
            {
                Id = acao.Id,
                IdEntidade = acao.IdEntidade,
                IdCategoria = acao.IdCategoria,
                Descricao = acao.Descricao,
                DataHora = acao.DataHora,
                Voluntarios = VoluntarioAdapter.ListParaDomain(acao.Voluntarios)
            };
        }

        public static AcaoDTO ParaDTO(Acao acao)
        {
            return new AcaoDTO()
            {
                Id = acao.Id,
                IdEntidade = acao.IdEntidade,
                IdCategoria = acao.IdCategoria,
                Descricao = acao.Descricao,
                DataHora = acao.DataHora,
                Voluntarios = VoluntarioAdapter.ListParaDTO(acao.Voluntarios)
            };
        }
    }
}
