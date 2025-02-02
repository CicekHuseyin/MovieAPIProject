using Microsoft.AspNetCore.Http;

namespace MovieProject.Model.Dtos.Artists;

public sealed record ArtistUpdateRequestDto
{
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public IFormFile? Image { get; init; }
    public DateTime BirthDate { get; init; }
}
