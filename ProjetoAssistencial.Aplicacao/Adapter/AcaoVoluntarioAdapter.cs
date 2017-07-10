using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class AcaoVoluntarioAdapter
    {

        public static AcaoVoluntario ParaDomain(AcaoVoluntarioDTO acaoVoluntario)
        {
            return new AcaoVoluntario()
            {
                Acao = AcaoAdapter.ParaDomain(acaoVoluntario.Acao),
                Voluntario = VoluntarioAdapter.ParaDomain(acaoVoluntario.Voluntario)
            };
        }

        public static AcaoVoluntarioDTO ParaDto(AcaoVoluntario acaoVoluntario)
        {
            return new AcaoVoluntarioDTO()
            {
                Acao = AcaoAdapter.ParaDTO(acaoVoluntario.Acao),
                Voluntario = VoluntarioAdapter.ParaDTO(acaoVoluntario.Voluntario)
            };
        }

    }
}
