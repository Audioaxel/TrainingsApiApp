
using DbAccessLib.DTOs;

namespace DbAccessLib.Data;

public interface IDatabaseRepository
{
    Task<TestModelDto> GetTest(int id);
}
