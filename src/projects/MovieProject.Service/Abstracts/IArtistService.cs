using MovieProject.Model.Dtos.Artists;

namespace MovieProject.Service.Abstracts;

public interface IArtistService
{
    Task<string> AddAsync(ArtistAddRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> UpdateAsync(ArtistUpdateRequestDto dto, CancellationToken cancellationToken = default);
    Task<string> DeleteAsync(long id, CancellationToken cancellationToken = default);
    Task<ArtistResponseDto> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<List<ArtistResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<List<ArtistResponseDto>> GetAllByMovieIdAsync(Guid movieId, CancellationToken cancellationToken = default);

}
