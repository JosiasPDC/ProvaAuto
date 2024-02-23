using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Base.Classes;
using Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Repository.Classes
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        BaseContext _dbContext;
        public ProdutoRepository(BaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Produto> BuscarComPaginacao(string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string CodigoFornecedor, string DescricaoFornecedor, string CNPJ)
        {
            var produtos = _dbContext.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
            {
                produtos = produtos.Where(p => p.Descricao.Contains(descricao));
            }

            if (situacao != null)
            {
                produtos = produtos.Where(p => p.Situacao == situacao);
            }

            if (dataFabricacaoMin != null)
            {
                produtos = produtos.Where(p => p.DataFabricacao >= dataFabricacaoMin);
            }

            if (dataFabricacaoMax != null)
            {
                produtos = produtos.Where(p => p.DataFabricacao <= dataFabricacaoMax);
            }

            return produtos.ToList();
        }
    }
}
