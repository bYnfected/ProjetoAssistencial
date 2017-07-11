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
    public class CategoriaAplicacao
    {

        private ICategoriaRepositorio categoriaRepositorio;

        public CategoriaAplicacao(ICategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public void Excluir(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id não informado");
            }

            this.categoriaRepositorio.Excluir(id);
        }

        public CategoriaDTO Procurar(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ApplicationException("Id nao informado");
            }

            Categoria categoria = this.categoriaRepositorio.Selecionar(id);

            return CategoriaAdapter.ParaDTO(categoria);
        }


        public List<CategoriaDTO> SelecionarTodos()
        {
            return CategoriaAdapter.ListParaDTO(categoriaRepositorio.SelecionarTodos());
        }

        public Guid Alterar(CategoriaDTO categoria)
        {
            Categoria categoriaItem = CategoriaAdapter.ParaDomain(categoria);

            if (string.IsNullOrEmpty(categoriaItem.Descricao))
            {
                throw new ApplicationException("Descrição não informada");
            }

            this.categoriaRepositorio.Alterar(categoriaItem);

            return categoriaItem.Id;
        }

        public Guid Inserir(CategoriaDTO categoria)
        {
            Categoria categoriaItem = CategoriaAdapter.ParaDomain(categoria);
            categoriaItem.Id = Guid.NewGuid();

            if (string.IsNullOrEmpty(categoriaItem.Descricao))
            {
                throw new ApplicationException("Descrição não informado");
            }

            this.categoriaRepositorio.Inserir(categoriaItem);

            return categoriaItem.Id;
        }



    }
}
