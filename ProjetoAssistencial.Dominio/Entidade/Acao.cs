using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Entidade
{
    public class Acao : Base
    {
        public Entidade Entidade { get; set; }

        public Categoria Categoria { get; set; }

        public String Descricao { get; set; }

        public DateTime DataHora { get; set; }

        public List<Voluntario> Voluntarios { get; set; }

    }
}
