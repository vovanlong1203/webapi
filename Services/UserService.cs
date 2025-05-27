using MyWebApi.Data;
using MyWebApi.DTOs;
using MyWebApi.Repositories;
using MyWebApi.Interfaces;

namespace MyWebApi.Services;

public class UserService : IUserService {
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            UserId = u.UserId,
            Username = u.Username,
            Email = u.Email,
            FullName = u.FullName,
            Role = u.Role,
            ClassId = u.ClassId
        });
    }

    public async Task<UserDto?> GetByIdAsync(int id) 
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            UserId = user.UserId,
            Username = user.Username,
            Email = user.Email,
            FullName = user.FullName,
            Role = user.Role,
            ClassId = user.ClassId
        };
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Email = dto.Email,
            FullName = dto.FullName,
            Role = dto.Role,
            ClassId = dto.ClassId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdUser = await _repository.CreateAsync(user);
        return new UserDto
        {
            UserId = createdUser.UserId,
            Username = createdUser.Username,
            Email = createdUser.Email,
            FullName = createdUser.FullName,
            Role = createdUser.Role,
            ClassId = createdUser.ClassId
        };
    }

    public async Task<UserDto?> UpdateAsync(int id, CreateUserDto dto)
    {
        var user = new User
        {
            UserId = id,
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Email = dto.Email,
            FullName = dto.FullName,
            Role = dto.Role,
            ClassId = dto.ClassId
        };

        var updatedUser = await _repository.UpdateAsync(id, user);
        if (updatedUser == null) return null;

        return new UserDto
        {
            UserId = updatedUser.UserId,
            Username = updatedUser.Username,
            Email = updatedUser.Email,
            FullName = updatedUser.FullName,
            Role = updatedUser.Role,
            ClassId = updatedUser.ClassId
        };
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}

