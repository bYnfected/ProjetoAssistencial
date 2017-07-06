using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.DTO
{
     public class VoluntarioDTO : Base
    {
        public String Nome { get; set; }

        public String Cidade { get; set; }

        public List<CategoriaDTO> Categorias { get; set; }
    }
}
