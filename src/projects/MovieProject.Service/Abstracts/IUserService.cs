using Core.Security.Entities;
using MovieProject.Model.Dtos.Users;

namespace MovieProject.Service.Abstracts;

public interface IUserService
{
    Task<List<UserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<UserResponseDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<UserResponseDto?> GetByUserNameAsync(string username, CancellationToken cancellationToken = default);
    Task<UserResponseDto?> AddAsync(User user, CancellationToken cancellationToken = default);
    Task<UserResponseDto?> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<UserResponseDto?> SetStatusAsync(int id,bool status);
    Task<UserResponseDto?> GetByIdAsync(int id);
}
