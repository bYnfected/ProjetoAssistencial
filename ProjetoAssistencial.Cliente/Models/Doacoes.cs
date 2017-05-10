using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Cliente.Models
{
    public class Doacoes
    {

        public Guid IdEntidade { get; set; }
        public Guid IdVoluntario { get; set; }
        public string Doacao { get; set; }
            
    }
}