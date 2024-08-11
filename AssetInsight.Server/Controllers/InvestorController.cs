using AssetInsight.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetInsight.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private static readonly IEnumerable<Investor> investors = new[]{

            new Investor {Id=1,Name="Hedge Funds", Type="GBP",DateAdded="", Address="", TotalCommitment="2.4B" },
            new Investor {Id=1,Name="Hedge Funds", Type="GBP",DateAdded="", Address="", TotalCommitment="2.4B" },
            new Investor {Id=1,Name="Hedge Funds", Type="GBP",DateAdded="", Address="", TotalCommitment="2.4B" },
        };

        private readonly ILogger<InvestorController> _logger;

        public InvestorController(ILogger<InvestorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Investor[] Get()
        {
            Investor[] results = investors.ToArray();
            return results;
        }

        [HttpGet("{id}")]
        public Investor[] Get(int id)
        {
            Investor[] results = investors.Where(i => i.Id == id).ToArray();
            return results;
        }
    }
}
