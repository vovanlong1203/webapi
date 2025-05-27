using MyWebApi.Data;

namespace MyWebApi.Interfaces;

public interface IClassRepository
{
    Task<IEnumerable<Class>> GetAllAsync();
    Task<Class?> GetByIdAsync(int id);
    Task<Class> CreateAsync(Class classEntity);
    Task<Class?> UpdateAsync(int id, Class classEntity);
    Task<bool> DeleteAsync(int id);
}