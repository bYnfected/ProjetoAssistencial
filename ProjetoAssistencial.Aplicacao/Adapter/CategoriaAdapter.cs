using ProjetoAssistencial.Aplicacao.DTO;
using ProjetoAssistencial.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAssistencial.Aplicacao.Adapter
{
    public class CategoriaAdapter
    {

        public static Categoria ParaDomain(CategoriaDTO categoria)
        {
            return new Categoria()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };
        }

        public static CategoriaDTO ParaDTO(Categoria categoria)
        {
            return new CategoriaDTO()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };
        }

        public static List<Categoria> ListParaDomain(List<CategoriaDTO> listaCategoriaDTO)
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            foreach (CategoriaDTO cat in listaCategoriaDTO)
            {
                listaCategoria.Add(CategoriaAdapter.ParaDomain(cat));   
            }
            return listaCategoria;
        }

        public static List<CategoriaDTO> ListParaDTO(List<Categoria> listaCategoria)
        {
            List<CategoriaDTO> listaCategoriaDTO = new List<CategoriaDTO>();
            foreach (Categoria cat in listaCategoria)
            {
                listaCategoriaDTO.Add(CategoriaAdapter.ParaDTO(cat));
            }
            return listaCategoriaDTO;
        }




    }
}
