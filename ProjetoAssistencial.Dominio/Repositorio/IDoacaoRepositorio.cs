using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface IDoacaoRepositorio
    {

        Guid Inserir(Doacao doacao);

        Guid Alterar(Doacao doacao);

        Doacao Selecionar(Guid id);

        List<Doacao> SelecionarTodos();

        void Excluir(Guid id);

    }
}
