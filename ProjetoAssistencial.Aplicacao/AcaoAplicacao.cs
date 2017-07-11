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
    public class AcaoAplicacao
    {
        private IAcaoRepositorio acaoRepositorio;

        public AcaoAplicacao(IAcaoRepositorio acaoRepositorio)
        {
            this.acaoRepositorio = acaoRepositorio;
        }

        public void Excluir(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            acaoRepositorio.Excluir(id);
        }

        public AcaoDTO Procurar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            Acao acao = this.acaoRepositorio.Selecionar(id);

            return AcaoAdapter.ParaDTO(acao);
        }

        public List<AcaoDTO> SelecionarTodos()
        {
            return AcaoAdapter.ListParaDTO(acaoRepositorio.SelecionarTodos());
        }

        public Guid Alterar(AcaoDTO acao)
        {
            Acao acaoItem = AcaoAdapter.ParaDomain(acao);

            if(string.IsNullOrEmpty(acao.Descricao))
            {
                throw new ApplicationException("Descrição não informada");
            }

            acaoRepositorio.Alterar(acaoItem);

            return acaoItem.Id;
        }

        public Guid Inserir(AcaoDTO acao)
        {
            Acao acaoItem = AcaoAdapter.ParaDomain(acao);
            acaoItem.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(acao.Descricao))
            {
                throw new ApplicationException("Descrição não informada");
            }

            return acaoItem.Id;
        }
    }
}
