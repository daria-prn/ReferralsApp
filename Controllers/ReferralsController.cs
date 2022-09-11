using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using ReferralsApp.Models;

namespace ReferralsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralsController : ControllerBase
    {
        private readonly ReferralContext _dbContext;

        public ReferralsController(ReferralContext dbContext)
        { 
            _dbContext = dbContext;
        }

        //GET: api/Referrals
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Referral>>> GetReferrals()
        {
            if (_dbContext.Referrals == null)
            {
                return NotFound("There are no items to display");
            }
            return await _dbContext.Referrals.ToListAsync();
        }

        //GET: api/Referrals/ReferralId
        [HttpGet("{id}")]

        public async Task<ActionResult<Referral>> GetReferral(int id)
        { 
            var referral = await _dbContext.Referrals.FindAsync(id);
            if (referral == null)
            {
                return NotFound("The referral does not exist");
            }
            return referral;
        }

        //POST : api/Referrals
        [HttpPost]

        public async Task<ActionResult<Referral>> PostReferral(Referral referral)
        { 
            _dbContext.Referrals.Add(referral);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReferral), new { id = referral.Id }, referral);
        }


        //PUT : api/Referrals/ReferralId
        [HttpPut("{id}")]

        public async Task<IActionResult> PutReferral(int id, Referral referral)
        {
            if (id != referral.Id)
            {
                return BadRequest();
            }
            referral.LastModified = DateTime.UtcNow;
            _dbContext.Entry(referral).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_dbContext.Referrals?.Any(e => e.Id == id)).GetValueOrDefault())
                {
                    return NotFound("The referral does not exist");
                }
                else 
                {
                    throw;
                }
            }
            return NoContent();
        }

        //DELETE : api/Referrals/ReferralId
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteReferral(int id)
        {

            if (_dbContext.Referrals == null)
            { 
                return NotFound("There are no items to display");
            }

            var referral = await _dbContext.Referrals.FindAsync(id);
            if (referral == null)
            { 
                return NotFound("The referral does not exist");
            }

            _dbContext.Referrals.Remove(referral);
            await _dbContext.SaveChangesAsync();

            return NoContent();

        }

    }
}
