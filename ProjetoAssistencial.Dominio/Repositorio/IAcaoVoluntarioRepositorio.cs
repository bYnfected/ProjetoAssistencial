using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Dominio.Repositorio
{
    public interface IAcaoVoluntarioRepositorio
    {

        bool Inserir(AcaoVoluntario acaoVoluntario);

    }
}
