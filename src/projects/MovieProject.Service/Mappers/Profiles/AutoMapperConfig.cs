using AutoMapper;
using Core.Security.Entities;
using MovieProject.Model.Dtos.Artists;
using MovieProject.Model.Dtos.Categories;
using MovieProject.Model.Dtos.Movies;
using MovieProject.Model.Dtos.Users;
using MovieProject.Model.Entities;

namespace MovieProject.Service.Mappers.Profiles;

public sealed class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<CategoryAddRequestDto, Category>();
        CreateMap<CategoryUpdateRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<MovieAddRequestDto, Movie>();
        CreateMap<MovieUpdateRequestDto, Movie>();
        CreateMap<Movie, MovieResponseDto>();

        CreateMap<ArtistAddRequestDto, Artist>();
        CreateMap<ArtistUpdateRequestDto, Artist>();
        CreateMap<Artist, ArtistResponseDto>();

        CreateMap<User, UserResponseDto>();
        CreateMap<RegisterRequestDto, User>();
    }
}
