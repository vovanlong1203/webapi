// QuizApi/Interfaces/IUserService.cs
using MyWebApi.DTOs;

namespace MyWebApi.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
    Task<UserDto?> UpdateAsync(int id, CreateUserDto dto);
    Task<bool> DeleteAsync(int id);
}