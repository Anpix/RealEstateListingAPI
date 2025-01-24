using AutoMapper;
using RealEstateListingApi.DTOs;
using RealEstateListingApi.Models;
using RealEstateListingApi.Repositories;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _repository;
    private readonly IMapper _mapper;

    public ListingService(IListingRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IEnumerable<ListingDto>> GetAll()
    {
        var result = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ListingDto>>(result);
    }

    public async Task<ListingDto?> GetById(Guid id)
    {
        var result = await _repository.GetById(id);
        return _mapper.Map<ListingDto>(result);
    }

    public async Task<ListingDto?> Create(CreateListingDto createDto)
    {
        var listing = new Listing
        {
            Id = Guid.NewGuid(),
            Title = createDto.Title,
            Price = createDto.Price,
            Description = createDto.Description
        };
        var result = await _repository.Create(listing);
        var dto = _mapper.Map<ListingDto>(result);
        return dto;
    }

    public async Task<bool> Delete(Guid id)
    {
        await _repository.Delete(id);
        return true;
    }

}
