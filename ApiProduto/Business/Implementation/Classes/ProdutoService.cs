using Data.Base.Interfaces;
using Data.Entities;
using Domain.Dtos;
using Domain.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using Data.Repository.Interfaces;
using System.Linq;

namespace Domain.Implementation.Classes
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }


        public Produto BuscarPorId(int codigo)
        {
            try
            {
                return _repository.GetById(codigo).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> Listar()
        {
            try
            {
                return _repository.GetAll().Result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserir(Produto produto)
        {
            try
            {
                _repository.Add(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                _repository.Update(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Produto produto)
        {
            try
            {
                produto.Situacao = false;
                _repository.Update(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> BuscarComPaginacao(string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string CodigoFornecedor, string DescricaoFornecedor, string CNPJ)
        {
            try
            {
                return _repository.BuscarComPaginacao(descricao, situacao, dataFabricacaoMin, dataFabricacaoMax, CodigoFornecedor, DescricaoFornecedor, CNPJ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
