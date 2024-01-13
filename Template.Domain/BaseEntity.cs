using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain
{
    public abstract class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("DT_CRIACAO")]
        public DateTime? DtCriacao { get; set; }
        [Column("DT_ATUALIZACAO")]
        public DateTime? DtAtualizacao { get; set; }
        [Column("DT_EXCLUSAO")]
        public DateTime? DtExclusao { get; set; }
    }
}
