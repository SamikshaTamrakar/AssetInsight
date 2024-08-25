using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AssetInsight.Server.Models
{
    public class Asset
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? AssestClass { get; set; }
        public string? Currency { get; set; }
        public string? Amount { get; set; }
        public string? InvestorName { get; set; }
        public string? InvestorType { get; set; }
        public string? InvestorCountry { get; set; }
        public string? InvestorDateAdded { get; set; }
        public string? InvestorLastUpdated { get; set; }
        public string? TotalCommitment { get; set; }

    }
}
