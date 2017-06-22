using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class CategoriaAdapter
    {

        public static Categoria ParaDomain(CategoriaDTO categoria)
        {
            return new Categoria()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };
        }

        public static CategoriaDTO ParaDto(Categoria categoria)
        {
            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };
        }

    }
}
