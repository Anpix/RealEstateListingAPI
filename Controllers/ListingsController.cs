using Microsoft.AspNetCore.Mvc;
using RealEstateListingApi.Models;
using RealEstateListingApi.Services;

namespace RealEstateListingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly IListingService _service;

        public ListingsController(IListingService service)
        {
            _service = service;
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet]
        [Tags("Listings Retrieval")]
        public async Task<ActionResult<IEnumerable<Listing>>> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        // Tag this operation as "Listings Management"
        [HttpPost]
        [Tags("Listings Management")]
        public async Task<ActionResult<Listing>> AddListing([FromBody] Listing listing)
        {
            var result = await _service.Create(listing);
            return CreatedAtAction(nameof(GetById), new { id = listing.Id }, listing);
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet("{id}")]
        [Tags("Listings Retrieval")]
        public async Task<ActionResult<Listing>> GetById(string id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound();

            return result;
        }

        // Tag this operation as "Deleting Listing"
        [HttpDelete("{id}")]
        [Tags("Deleting Listing")]
        public async Task<ActionResult> DeleteById(string id)
        {
            var result = await _service.Delete(id);
            return result ? Ok() : NotFound();
        }
    }
}
