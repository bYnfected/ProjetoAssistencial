using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface ICategoriaRepositorio
    {

        Guid Inserir(Categoria categoria);

        Guid Alterar(Categoria categoria);

        Categoria Selecionar(Guid id);

        List<Categoria> SelecionarTodos();

        void Excluir(Guid id);

    }
}
