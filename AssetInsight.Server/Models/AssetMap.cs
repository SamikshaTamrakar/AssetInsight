using CsvHelper.Configuration;
using System.Collections.Generic;

namespace AssetInsight.Server.Models
{
    public class AssetMap : ClassMap<Asset>
    {
        public AssetMap()
        {
            Map(m => m.InvestorName).Name("Investor Name");
            Map(m => m.InvestorType).Name("Investory Type");
            Map(m => m.InvestorCountry).Name("Investor Country");
            Map(m => m.InvestorDateAdded).Name("Investor Date Added");
            Map(m => m.InvestorLastUpdated).Name("Investor Last Updated");
            Map(m => m.AssestClass).Name("Commitment Asset Class");
            Map(m => m.Amount).Name("Commitment Amount");
            Map(m => m.Currency).Name("Commitment Currency");

        }
    }
}
