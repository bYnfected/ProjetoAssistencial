using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Entidade
{
    public class Doacao: Base
    {

        public string Descricao { get; set; }
        public Entidade Entidade { get; set; }
        public Categoria Categoria { get; set; }
        public Voluntario Voluntario { get; set; }

        public Doacao()
        {

        }

    }
}
