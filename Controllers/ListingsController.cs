using Microsoft.AspNetCore.Mvc;
using RealEstateListingApi.DTOs;
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
        public async Task<ActionResult<IEnumerable<ListingDto>>> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        // Tag this operation as "Listings Management"
        [HttpPost]
        [Tags("Listings Management")]
        public async Task<ActionResult<ListingDto>> AddListing([FromBody] CreateListingDto dto)
        {
            var result = await _service.Create(dto);
            if(result == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet("{id}")]
        [Tags("Listings Retrieval")]
        public async Task<ActionResult<ListingDto>> GetById(string id)
        {
            var guid = Guid.Empty;
            if (!Guid.TryParse(id, out guid))
                return BadRequest();

            var result = await _service.GetById(guid);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // Tag this operation as "Deleting Listing"
        [HttpDelete("{id}")]
        [Tags("Deleting Listing")]
        public async Task<ActionResult> DeleteById(string id)
        {
            var guid = Guid.Empty;
            if(!Guid.TryParse(id, out guid))
                return BadRequest();

            var result = await _service.Delete(guid);
            return result ? Ok() : NotFound();
        }
    }
}
