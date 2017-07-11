using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface IVoluntarioRepositorio
    {
        Guid Inserir(Voluntario voluntario);

        Guid Alterar(Voluntario voluntario);

        Voluntario Selecionar(Guid id);

        List<Voluntario> SelecionarTodos();

        void Excluir(Guid id);
    }
}
