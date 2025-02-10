﻿using AutoMapper;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Model.Dtos.Artists;
using MovieProject.Model.Entities;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Artists;
using MovieProject.Service.Constants.Artists;
using MovieProject.Service.Helpers;

namespace MovieProject.Service.Concretes;

public sealed class ArtistService : IArtistService
{
    private readonly IMapper _mapper;
    private readonly IArtistRepository _artistRepository;
    private readonly ArtistBusinessRules _businessRules;
    private readonly ICloudinaryHelper _cloudinaryHelper;

    public ArtistService(IMapper mapper, IArtistRepository artistRepository, ArtistBusinessRules businessRules, ICloudinaryHelper cloudinaryHelper)
    {
        _mapper = mapper;
        _artistRepository = artistRepository;
        _businessRules = businessRules;
        _cloudinaryHelper = cloudinaryHelper;
    }

    public async Task<string> AddAsync(ArtistAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.ArtistFullNameMustBeUniqueAsync(dto.Name, dto.Surname);
        Artist artist = _mapper.Map<Artist>(dto);
        string url = await _cloudinaryHelper.UploadImageAsync(dto.Image, "movie-artist");
        artist.ImageUrl = url;
        await _artistRepository.AddAsync(artist, cancellationToken);
        return ArtistMessages.ArtistAddedMessage;

    }

    public async Task<string> DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        await _businessRules.ArtistIsPresentAsync(id);
        var artist = await _artistRepository.GetAsync(
            filter: x => x.Id == id,
            include: false,
            cancellationToken: cancellationToken);
        await _artistRepository.DeleteAsync(artist, cancellationToken);
        return ArtistMessages.ArtistDeletedMessage;
    }

    public async Task<List<ArtistResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var artist = await _artistRepository.GetAllAsync(
            enableTracking: false,
            cancellationToken: cancellationToken
            );

        var response= _mapper.Map<List<ArtistResponseDto>>(artist);
        return response;
    }

    public Task<List<ArtistResponseDto>> GetAllByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ArtistResponseDto> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        await _businessRules.ArtistIsPresentAsync(id);
        var artist = await _artistRepository.GetAsync(
            filter: x => x.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
            );
        var response = _mapper.Map<ArtistResponseDto>(artist);
        return response;
    }

    public async Task<string> UpdateAsync(ArtistUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.ArtistIsPresentAsync(dto.Id);
        Artist artist = _mapper.Map<Artist>(dto);
        await _artistRepository.UpdateAsync(artist,cancellationToken);
        return ArtistMessages.ArtistUpdatedMessage;
    }
}
