using ProjetoAssistencial.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface IEntidadeRepositorio
    {

        Guid Inserir(Entidade.Entidade categoria);

        Guid Alterar(Entidade.Entidade categoria);

        Entidade.Entidade Selecionar(Guid id);

        List<Entidade.Entidade> SelecionarTodos();

        void Excluir(Guid id);

    }
}
