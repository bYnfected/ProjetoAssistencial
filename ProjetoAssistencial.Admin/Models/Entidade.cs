using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAssistencial.Admin.Models
{
    public class Entidade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Liberado { get; set; }

        
    }
}