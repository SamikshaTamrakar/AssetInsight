using Microsoft.AspNetCore.Mvc;
using AssetInsight.Server.Models;
using AssetInsight.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AssetInsight.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private AssetInsightDBContext dbContext;

        private readonly ILogger<AssetController> _logger;

        public AssetController(ILogger<AssetController> logger, AssetInsightDBContext db)
        {
            _logger = logger;
            dbContext = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asset))]
        public ActionResult Get()
        {
            var results = dbContext.Asset.ToList();
            return Ok(results);
        }

        [HttpGet("{id}", Name ="GetAssettById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asset))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByID(int id)
        {
            var results = await dbContext.Asset.SingleOrDefaultAsync(c=>c.Id == id);
            if (results == null) return NotFound();
            else
            return Ok(results);
            
        }

        [HttpGet(("filter/assetClass"), Name = "GetAssettByAssetClass")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asset))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByAssetClass(string assetClass)
        {
            var results = new List<Asset>();
            if (string.IsNullOrEmpty(assetClass))
            {
                return NotFound();
            }
            if(assetClass == "All")
            {
                results = dbContext.Asset.ToList();
            }
            else
            {
                results = await dbContext.Asset.Where(c => c.AssestClass == assetClass).ToListAsync();
            }
            if (results == null) return NotFound();
            else
                return Ok(results);

        }

        [HttpPost(Name ="AddAsset")]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(Asset))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddAsset([FromBody] Asset asset)
        {
            TryValidateModel(asset);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Asset assetData = new Asset()
                {
                    AssestClass = asset.AssestClass,
                    Currency = asset.Currency,
                    Amount = asset.Amount,
                    InvestorName = asset.InvestorName,
                    InvestorType = asset.InvestorType,
                    InvestorCountry = asset.InvestorCountry,
                    InvestorDateAdded = asset.InvestorDateAdded,
                    InvestorLastUpdated = asset.InvestorLastUpdated,
                    TotalCommitment = asset.TotalCommitment
                };
                await dbContext.Asset.AddAsync(assetData);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            
        }

        // POST: api/CsvUpload
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                using (var stream = new StreamReader(file.OpenReadStream()))
                using (var csv = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    IgnoreBlankLines = true
                }))
                {
                    try
                    {
                        csv.Context.RegisterClassMap<AssetMap>();
                        var records = csv.GetRecords<Asset>();
                        await dbContext.Asset.AddRangeAsync(records);
                        await dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, $"Error parsing CSV file: {ex.Message}");
                    }
                }

                return Ok("File processed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error processing file: {ex.Message}");
            }
        }
        [HttpDelete]
        public void DeleteAllData()
        {
            var tables = dbContext.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .Distinct();

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                foreach (var table in tables)
                {
                    dbContext.Database.ExecuteSqlRaw($"DELETE FROM {table};");
                }

                transaction.Commit();
            }
        }
    }
}
