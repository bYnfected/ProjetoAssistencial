using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.Models
{
    public class Doacao
    {

        public Guid Id { get; set; }

        public Entidade Entidade { get; set; }

        public Categoria Categoria { get; set; }

        public Voluntario Voluntario { get; set; }

        public string Descricao { get; set; }
            
    }
}