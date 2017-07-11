using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface IAcaoRepositorio
    {
        Guid Inserir(Acao acao);

        Guid Alterar(Acao acao);

        Acao Selecionar(Guid id);

        List<Acao> SelecionarTodos();

        void Excluir(Guid id);

    }
}
