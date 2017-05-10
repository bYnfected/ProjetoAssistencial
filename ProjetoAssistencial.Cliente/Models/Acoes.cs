using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.Models
{
    public class Acoes
    {

        public Guid idEntidade { get; set; }
        public Guid IdVoluntario { get; set; }
        public string Acao { get; set; }

    }
}