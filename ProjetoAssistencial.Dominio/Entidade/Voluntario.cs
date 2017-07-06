using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Entidade
{
    class Voluntario : Base
    {
        public String Nome { get; set; }

        public String Cidade { get; set; }

        public List<Categoria> Categorias { get; set; }
    }
}
