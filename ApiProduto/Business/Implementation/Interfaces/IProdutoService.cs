using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Implementation.Interfaces
{
    public interface IProdutoService
    {
        public Produto BuscarPorId(int codigo);
        public List<Produto> Listar();
        public void Inserir(Produto produto);
        public void Editar(Produto produto);
        public void Excluir(Produto produto);
        public List<Produto> BuscarComPaginacao(string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string CodigoFornecedor, string DescricaoFornecedor, string CNPJ);
        //object BuscarComPaginacao(string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string codigoFornecedor, string descricaoFornecedor, string cNPJ);
    }
}
