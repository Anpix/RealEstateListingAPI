using Microsoft.AspNetCore.Mvc;
using RealEstateListingApi.Data;
using RealEstateListingApi.Models;
using RealEstateListingApi.Services;

namespace RealEstateListingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IListingService _service;

        public ListingsController(IListingService service)
        {
            _service = service;
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet]
        [Tags("Listings Retrieval")]
        public ActionResult<IEnumerable<Listing>> GetAll()
        {
            return _service.GetAll().ToList();
        }

        // Tag this operation as "Listings Management"
        [HttpPost]
        [Tags("Listings Management")]
        public ActionResult<Listing> AddListing([FromBody] Listing listing)
        {
            _service.Create(listing);
            return CreatedAtAction(nameof(GetById), new { id = listing.Id }, listing);
        }

        // Tag this operation as "Listings Retrieval"
        [HttpGet("{id}")]
        [Tags("Listings Retrieval")]
        public ActionResult<Listing> GetById(string id)
        {
            var result = _service.GetById(id);

            if (result == null)
                return NotFound();

            return result;
        }

        // Tag this operation as "Deleting Listing"
        [HttpDelete("{id}")]
        [Tags("Deleting Listing")]
        public ActionResult DeleteById(string id)
        {
            var result = _service.Delete(id);
            return result ? Ok() : NotFound();
        }
    }
}
