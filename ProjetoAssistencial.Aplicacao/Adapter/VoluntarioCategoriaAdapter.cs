using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class VoluntarioCategoriaAdapter
    {

        public static VoluntarioCategoria ParaDomain(VoluntarioCategoriaDTO voluntarioCategoria)
        {
            return new VoluntarioCategoria()
            {
                Categoria = voluntarioCategoria.Categoria,
                Voluntario = voluntarioCategoria.Voluntario
            };
        }

        public static VoluntarioCategoriaDTO ParaDto(VoluntarioCategoria voluntarioCategoria)
        {
            return new VoluntarioCategoriaDTO()
            {
                Categoria = voluntarioCategoria.Categoria,
                Voluntario = voluntarioCategoria.Voluntario
            };
        }

    }
}
