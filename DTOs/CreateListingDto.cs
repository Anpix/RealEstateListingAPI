﻿namespace RealEstateListingApi.DTOs;

public class CreateListingDto
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
