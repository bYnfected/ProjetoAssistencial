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
    public class DoacaoAplicacao
    {

        private IDoacaoRepositorio doacaoRepositorio;

        public DoacaoAplicacao(IDoacaoRepositorio doacaoRepositorio)
        {
            this.doacaoRepositorio = doacaoRepositorio;
        }

        public void Excluir(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            this.doacaoRepositorio.Excluir(id);
        }

        public DoacaoDTO Procurar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id nao informado");
            }

            Doacao doacao = this.doacaoRepositorio.Selecionar(id);

            return DoacaoAdapter.ParaDto(doacao);
        }


        public List<DoacaoDTO> SelecionarTodos()
        {
            List<Doacao> listaDoacoes = this.doacaoRepositorio.SelecionarTodos();
            List<DoacaoDTO> listaDoacoesDTO = new List<DTO.DoacaoDTO>();

            foreach (Doacao item in listaDoacoes)
            {
                listaDoacoesDTO.Add(DoacaoAdapter.ParaDto(item));
            }

            return listaDoacoesDTO;
        }

        public Guid Alterar(DoacaoDTO doacao)
        {
            Doacao doacaoItem = DoacaoAdapter.ParaDomain(doacao);

            if (string.IsNullOrEmpty(doacaoItem.Descricao))
            {
                throw new ApplicationException("Descrição não informada");
            }

            this.doacaoRepositorio.Alterar(doacaoItem);

            return doacaoItem.Id;
        }

        public Guid Inserir(DoacaoDTO doacao)
        {
            Doacao doacaoItem = DoacaoAdapter.ParaDomain(doacao);
            doacaoItem.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(doacaoItem.Descricao))
            {
                throw new ApplicationException("Descrição não informado");
            }

            this.doacaoRepositorio.Inserir(doacaoItem);

            return doacaoItem.Id;
        }



    }
}
