using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.DTO
{
    public class DoacaoDTO
    {

        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public EntidadeDTO Entidade { get; set;  }

        public CategoriaDTO Categoria { get; set;  }

    }
}
