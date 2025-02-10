using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Service.Abstracts;
using MovieProject.Service.BusinessRules.Artists;
using MovieProject.Service.BusinessRules.Categories;
using MovieProject.Service.BusinessRules.Movies;
using MovieProject.Service.Concretes;
using MovieProject.Service.Helpers;
using MovieProject.Service.Mappers.Categories;
using MovieProject.Service.Mappers.Profiles;
using System.Reflection;

namespace MovieProject.Service;

public static class ServiceRegistration
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IArtistService, ArtistService>();
        services.AddScoped<MovieBusinessRules>();
        services.AddScoped<ArtistBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<ICloudinaryHelper, CloudinaryHelper>();
        services.AddScoped<ICategoryMapper, CategoryAutoMapper>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
