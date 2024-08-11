using Microsoft.AspNetCore.Mvc;
using AssetInsight.Server.Models;
using AssetInsight.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace AssetInsight.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommitmentController : ControllerBase
    {
        private AssetInsightDBContext dbContext;

        private readonly ILogger<CommitmentController> _logger;

        public CommitmentController(ILogger<CommitmentController> logger, AssetInsightDBContext db)
        {
            _logger = logger;
            dbContext = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Commitment))]
        public ActionResult Get()
        {
            var results = dbContext.Commitments.ToList();
            return Ok(results);
        }

        [HttpGet("{id}", Name ="GetCommitmentById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Commitment))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var results = dbContext.Commitments.SingleOrDefaultAsync(c=>c.Id == id);
            if (results == null) return NotFound();
            else
            return Ok(results);
            
        }

        [HttpPost(Name ="AddCommitment")]
        [ProducesResponseType(StatusCodes.Status201Created, Type=typeof(Commitment))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCommitments([FromBody] Commitment commitment)
        {
            TryValidateModel(commitment);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Commitment com = new Commitment()
                {
                    AssestClass = commitment.AssestClass,
                    Currency = commitment.Currency,
                    Amount = commitment.Amount,
                };
                await dbContext.Commitments.AddAsync(com);
                await dbContext.SaveChangesAsync();
                return CreatedAtRoute("GetCommitmentById", new {id = commitment.Id}, commitment);
            }
            
        }

    }
}
