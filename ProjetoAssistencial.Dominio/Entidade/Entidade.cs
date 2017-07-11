using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Entidade
{
    public class Entidade : Base
    {
        public String Nome { get; set; }

        public String Cidade { get; set; }

        public Boolean Liberado { get; set; }

        public List<Categoria> Categorias { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

    }
}
