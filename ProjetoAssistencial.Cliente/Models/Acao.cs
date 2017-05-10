using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.Models
{
    public class Acao
    {
        public Guid Id { get; set; }

        public Guid IdEntidade { get; set; }

        public Guid IdCategoria { get; set; }
        public List<Voluntario> Voluntarios { get; set; }
        public string Descricao { get; set; }

        public DateTime DataHora { get; set; }

    }
}