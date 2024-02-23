using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Domain.Implementation.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using X.PagedList;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("{codigo}")]
        public IActionResult BuscarPorId(int codigo)
        {
            var product = _produtoService.BuscarPorId(codigo);

            // Retorna 200 de sucesso com corpo na resposta
            if (product != null)
                return Ok(product);

            //Retorna um HTTP 204 No Content para indicar que a atualização foi bem - sucedida
            return NotFound();
        }

        [HttpGet]
        public IActionResult Listar(int? pagina, string descricao, bool? situacao, DateTime? dataFabricacaoMin, DateTime? dataFabricacaoMax, string CodigoFornecedor, string DescricaoFornecedor, string CNPJ)
        {
            int numeroDaPagina = pagina ?? 1;
            int tamanhoDaPagina = 2; // Especificar o número de itens por página

            IEnumerable<Produto> produtos = _produtoService.BuscarComPaginacao(descricao, situacao, dataFabricacaoMin, dataFabricacaoMax, CodigoFornecedor, DescricaoFornecedor, CNPJ)
                                          .ToPagedList(numeroDaPagina, tamanhoDaPagina);
            // Retorna 200 de sucesso com corpo na resposta
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Inserir(Produto produto)
        {
            _produtoService.Inserir(produto);
            // Retorna 201 de objeto criado
            return CreatedAtAction(nameof(BuscarPorId), new { codigo = produto.Codigo }, produto); ;
        }


        [HttpPut]
        public IActionResult Editar(Produto produto)
        {
            var produtoExistente = _produtoService.BuscarPorId(produto.Codigo);
            if (produtoExistente == null)
            {
                // Retorna HTTP 404 Not Found se o produto não for encontrado
                return NotFound();
            }

            _produtoService.Editar(produtoExistente.Atualizar(produto));

            // Retorna um HTTP 204 No Content para indicar que a atualização foi bem-sucedida
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Excluir(int codigo)
        {
            var produtoExistente = _produtoService.BuscarPorId(codigo);
            if (produtoExistente == null)
            {
                // Retorna HTTP 404 Not Found se o produto não for encontrado
                return NotFound();
            }

            _produtoService.Excluir(produtoExistente);

            // Retorna um HTTP 204 No Content para indicar que a atualização foi bem-sucedida
            return NoContent();
        }
    }
}
