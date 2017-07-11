using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Aplicacao.DTO;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    class VoluntarioAdapter
    {

        public static Voluntario ParaDomain(VoluntarioDTO voluntario)
        {
                return new Voluntario()
                {
                    Id = voluntario.Id,
                    Nome = voluntario.Nome,
                    Cidade = voluntario.Cidade,
                    Categorias = CategoriaAdapter.ListParaDomain(voluntario.Categorias)
            };
        }

        public static VoluntarioDTO ParaDTO(Voluntario voluntario)
        {
            return new VoluntarioDTO()
            {
                Id = voluntario.Id,
                Nome = voluntario.Nome,
                Cidade = voluntario.Cidade,
                Categorias = CategoriaAdapter.ListParaDTO(voluntario.Categorias)
            };
        }

        public static List<Voluntario> ListParaDomain(List<VoluntarioDTO> listaVoluntarioDTO)
        {
            List<Voluntario> listaVoluntario = new List<Voluntario>();

            foreach (VoluntarioDTO voluntario in listaVoluntarioDTO)
            {
                listaVoluntario.Add(VoluntarioAdapter.ParaDomain(voluntario));
            }
            return listaVoluntario;
        }

        public static List<VoluntarioDTO> ListParaDTO(List<Voluntario> listaVoluntario)
        {
            List<VoluntarioDTO> listaVoluntarioDTO = new List<VoluntarioDTO>();

            foreach (Voluntario voluntario in listaVoluntario)
            {
                listaVoluntarioDTO.Add(VoluntarioAdapter.ParaDTO(voluntario));
            }
            return listaVoluntarioDTO;
        }

    }
}
