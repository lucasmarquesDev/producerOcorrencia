using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    [Table("TB_OCORRENCIA")]
    public sealed class Ocorrencia : BaseEntity
    {
        [Column("ENDERECO_COMPLETO")]
        public string? EnderecoCompleto { get; set; }
        [Column("QTN_VOLUMES")]
        public int? QuantidadeVolumes { get; set; }
    }
}
