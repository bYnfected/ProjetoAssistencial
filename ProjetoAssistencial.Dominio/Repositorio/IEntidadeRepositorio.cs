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

        Guid Inserir(Dominio.Entidade.Entidade categoria);

        Guid Alterar(Dominio.Entidade.Entidade categoria);

        Dominio.Entidade.Entidade Selecionar(Guid id);

        List<Dominio.Entidade.Entidade> SelecionarTodos();

        void Excluir(Guid id);

    }
}
