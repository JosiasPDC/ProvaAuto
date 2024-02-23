using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Produto : IValidatableObject
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJ { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataFabricacao != null && DataValidade != null)
                if (DataFabricacao > DataValidade)
                yield return new ValidationResult("Data de fabricação não pode ser maior que data de validade.", new[] { nameof(DataFabricacao), nameof(DataValidade) });
        }

        public Produto Atualizar(Produto produto)
        {
            Descricao = produto.Descricao;
            Situacao = produto.Situacao;
            DataFabricacao = produto.DataFabricacao;
            DataValidade = produto.DataValidade;
            CodigoFornecedor = produto.CodigoFornecedor;
            DescricaoFornecedor = produto.DescricaoFornecedor;
            CNPJ = produto.CNPJ;

            return this;
        }
    }
}
