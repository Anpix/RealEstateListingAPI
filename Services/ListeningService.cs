using AutoMapper;
using RealEstateListingApi.DTOs;
using RealEstateListingApi.Models;
using RealEstateListingApi.Repositories;

namespace RealEstateListingApi.Services;

public class ListingService : IListingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListingService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ListingDto>> GetAll()
    {
        var result = await _unitOfWork.ListingRepository.GetAll();
        return _mapper.Map<IEnumerable<ListingDto>>(result);
    }

    public async Task<ListingDto?> GetById(Guid id)
    {
        var result = await _unitOfWork.ListingRepository.GetById(id);
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
        var result = await _unitOfWork.ListingRepository.Create(listing);
        var dto = _mapper.Map<ListingDto>(result);
        return dto;
    }

    public async Task<bool> Delete(Guid id)
    {
        await _unitOfWork.ListingRepository.Delete(id);
        return true;
    }

}
