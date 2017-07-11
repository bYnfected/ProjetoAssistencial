using ProjetoAssistencial.Aplicacao.Adapter;
using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using ProjetoAssistencial.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao
{
    public class VoluntarioAplicacao
    {
        private IVoluntarioRepositorio voluntarioRepositorio;

        public VoluntarioAplicacao(IVoluntarioRepositorio voluntarioRepositorio)
        {
            this.voluntarioRepositorio = voluntarioRepositorio;
        }

        public void Excluir (Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            voluntarioRepositorio.Excluir(id);
        }

        public VoluntarioDTO Procurar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            Voluntario voluntario = voluntarioRepositorio.Selecionar(id);

            return VoluntarioAdapter.ParaDTO(voluntario);
        }

        public List<VoluntarioDTO> SelecionarTodos()
        {
            return VoluntarioAdapter.ListParaDTO(voluntarioRepositorio.SelecionarTodos());
        }

        public Guid Alterar(VoluntarioDTO voluntario)
        {
            Voluntario voluntarioItem = VoluntarioAdapter.ParaDomain(voluntario);

            if(string.IsNullOrEmpty(voluntario.Nome))
            {
                throw new ApplicationException("Nome não informado");
            }

            voluntarioRepositorio.Alterar(voluntarioItem);

            return voluntarioItem.Id;
        }

        public Guid Inserir(VoluntarioDTO voluntario)
        {
            Voluntario voluntarioItem = VoluntarioAdapter.ParaDomain(voluntario);
            voluntarioItem.Id = Guid.NewGuid();

            if(string.IsNullOrEmpty(voluntarioItem.Nome))
            {
                throw new ApplicationException("Nome não informado");
            }

            voluntarioRepositorio.Inserir(voluntarioItem);

            return voluntarioItem.Id;
        }
    }
}
