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

        public static List<Acao> ListParaDomain (List<AcaoDTO> listAcaoDTO)
        {
            List<Acao> listAcao = new List<Acao>();

            foreach (AcaoDTO item in listAcaoDTO)
            {
                listAcao.Add(AcaoAdapter.ParaDomain(item));
            }

            return listAcao;
        }

        public static List<AcaoDTO> ListParaDTO(List<Acao> listaAcao)
        {
            List<AcaoDTO> listAcaoDTO = new List<AcaoDTO>();

            foreach (Acao item in listaAcao)
            {
                listAcaoDTO.Add(AcaoAdapter.ParaDTO(item));
            }

            return listAcaoDTO;
        }

    }
}
