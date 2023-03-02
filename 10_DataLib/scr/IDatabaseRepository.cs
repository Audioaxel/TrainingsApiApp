
namespace DataLib;

public interface IDatabaseRepository<T>
{
    Task<T> Get(int id);
}