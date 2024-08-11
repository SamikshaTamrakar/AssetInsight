using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetInsight.Server.Models
{
    public class Commitment
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? AssestClass { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }
    }
}
