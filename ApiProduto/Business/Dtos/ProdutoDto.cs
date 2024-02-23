using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class ProdutoDto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool? Situacao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJ { get; set; }
    }
}
