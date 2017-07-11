using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.Models
{
    public class Entidade
    {

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public bool Liberado { get; set; }

        public string Cidade { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

    }
}