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
    public class EntidadeAplicacao
    {
        private IEntidadeRepositorio entidadeRepositorio;

        public EntidadeAplicacao(IEntidadeRepositorio entidadeRepositorio)
        {
            this.entidadeRepositorio = entidadeRepositorio;
        }

        public void Excluir(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            entidadeRepositorio.Excluir(id);
        }

        public EntidadeDTO Procurar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            Entidade entidade = this.entidadeRepositorio.Selecionar(id);

            return EntidadeAdapter.ParaDTO(entidade);
        }

        public List<EntidadeDTO> SelecionarTodos()
        {
            return EntidadeAdapter.ListParaDTO(entidadeRepositorio.SelecionarTodos());
        }
        
        public Guid Alterar(EntidadeDTO entidade)
        {
            Entidade entidadeItem = EntidadeAdapter.ParaDomain(entidade);

            if(string.IsNullOrEmpty(entidadeItem.Nome))
            {
                throw new ApplicationException("Nome não informado");
            }

            entidadeRepositorio.Alterar(entidadeItem);

            return entidadeItem.Id;
        }
        
        public Guid Inserir(EntidadeDTO entidade)
        {
            Entidade entidadeItem = EntidadeAdapter.ParaDomain(entidade);
            entidadeItem.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(entidadeItem.Nome))
            {
                throw new ApplicationException("Nome não informado");
            }

            entidadeRepositorio.Inserir(entidadeItem);

            return entidadeItem.Id;
        }
    }
}
