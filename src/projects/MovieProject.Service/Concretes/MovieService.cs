﻿using AutoMapper;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieProject.DataAccess.Repositories.Abstracts;
using MovieProject.Model.Dtos.Movies;
using MovieProject.Model.Entities;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.Constants.Movies;
using MovieProject.Service.Helpers;

namespace MovieProject.Service.Concretes;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryHelper _cloudinaryHelper;
    private readonly MovieBusinessRules _businessRules;

    public MovieService(IMovieRepository movieRepository, IMapper mapper, ICloudinaryHelper cloudinaryHelper, MovieBusinessRules businessRules)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
        _cloudinaryHelper = cloudinaryHelper;
        _businessRules = businessRules;
    }

    public async Task<string> AddAsync(MovieAddRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.MovieTitleMustBeUniqueAsync(dto.Name);

        Movie movie = _mapper.Map<Movie>(dto);

        string url = await _cloudinaryHelper.UploadImageAsync(dto.Image, "movie-store");

        movie.ImageUrl = url;

        await _movieRepository.AddAsync(movie, cancellationToken);

        return MovieMessages.MovieAddedMessage;

    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _businessRules.MovieIsPresentAsync(id);

        Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == id, include: false, cancellationToken: cancellationToken);

        await _movieRepository.DeleteAsync(movie, cancellationToken);
    }

    public async Task<List<MovieResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Movie> movies = await _movieRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<List<MovieResponseDto>>(movies);
        return movieResponseDtos;

    }

    public async Task<List<MovieResponseDto>> GetAllByCategoryIdAsync(int id, CancellationToken cancellationToken = default)
    {
        List<Movie> movies = await _movieRepository.GetAllAsync(filter: x => x.CategoryId == id, enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<List<MovieResponseDto>>(movies);
        return movieResponseDtos;
    }

    public async Task<List<MovieResponseDto>> GetAllByDirectorIdAsync(long id, CancellationToken cancellationToken = default)
    {
        List<Movie> movies = await _movieRepository.GetAllAsync(filter: x => x.DirectorId == id, enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<List<MovieResponseDto>>(movies);
        return movieResponseDtos;
    }

    public async Task<List<MovieResponseDto>> GetAllByImdbRangeAsync(double min, double max, CancellationToken cancellationToken = default)
    {
        List<Movie> movies = await _movieRepository.GetAllAsync(filter: x => x.IMDB <= max && x.IMDB >= min, enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<List<MovieResponseDto>>(movies);
        return movieResponseDtos;
    }

    public async Task<List<MovieResponseDto>> GetAllByIsActiveAsync(bool active, CancellationToken cancellationToken = default)
    {
        List<Movie> movies = await _movieRepository.GetAllAsync(filter: x => x.IsActive == active, enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<List<MovieResponseDto>>(movies);
        return movieResponseDtos;
    }

    public async Task<MovieResponseDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _businessRules.MovieIsPresentAsync(id);

        Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == id, enableTracking: false, cancellationToken: cancellationToken);
        var movieResponseDtos = _mapper.Map<MovieResponseDto>(movie);
        return movieResponseDtos;
    }

    public async Task UpdateAsync(MovieUpdateRequestDto dto, CancellationToken cancellationToken = default)
    {
        await _businessRules.MovieIsPresentAsync(dto.Id);
        //Movie movie = await _movieRepository.GetAsync(filter: x => x.Id == dto.Id, include: false, cancellationToken: cancellationToken);
        Movie movie = _mapper.Map<Movie>(dto);
        await _movieRepository.UpdateAsync(movie,cancellationToken);
    }
}
