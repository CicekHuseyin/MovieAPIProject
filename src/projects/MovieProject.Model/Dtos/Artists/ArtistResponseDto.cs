namespace MovieProject.Model.Dtos.Artists;

public sealed record ArtistResponseDto
{
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Surname { get; init; }
    public string? ImageUrl { get; init; }
    public DateTime BirthDate { get; init; }
    public string? FullName { get; init; }
}
