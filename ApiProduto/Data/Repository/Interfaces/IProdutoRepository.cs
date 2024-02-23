using Data.Base.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        List<Produto> BuscarComPaginacao(string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string CodigoFornecedor, string DescricaoFornecedor, string CNPJ);
    }
}
