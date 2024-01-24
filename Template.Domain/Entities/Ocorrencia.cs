using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Domain.Entities
{
    public sealed class Ocorrencia : BaseEntity
    {
        public string? EnderecoCompleto { get; set; }
        public int? QuantidadeVolumes { get; set; }
    }
}
