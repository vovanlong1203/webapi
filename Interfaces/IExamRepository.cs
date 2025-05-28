using MyWebApi.Data;

namespace MyWebApi.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam?> GetByIdAsync(int id);
        Task<Exam> CreateAsync(Exam exam);
        Task<Exam?> UpdateAsync(int id, Exam exam);
        Task<bool> DeleteAsync(int id);
    }
}