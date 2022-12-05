using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinglePageASPNET.Models
{
    [Table("ForOverRows")]
    public class ForRowOvers
    {
        [Key]
        [Column("rowNumber")]
        public int RowNumber { get; set; }
        [Column("TextNumber")]
        [Required]
        public string TextNumber { get; set; }
    }
}
