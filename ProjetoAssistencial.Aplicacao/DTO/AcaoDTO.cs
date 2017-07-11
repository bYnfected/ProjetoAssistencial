using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.DTO
{
    public class AcaoDTO : Base
    {
        public Guid Entidade { get; set; }

        public Guid Categoria { get; set; }

        public String Descricao { get; set; }

        public DateTime DataHora { get; set; }

        public List<VoluntarioDTO> Voluntarios { get; set; }
    }
}
