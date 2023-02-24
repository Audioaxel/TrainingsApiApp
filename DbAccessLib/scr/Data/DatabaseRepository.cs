using AutoMapper;
using DbAccessLib.DataAccess;
using DbAccessLib.DTOs;

namespace DbAccessLib.Data;

public class DatabaseRepository : IDatabaseRepository
{
    private readonly DatabaseDbContext _context;
    private readonly IMapper _mapper;

    public DatabaseRepository(DatabaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TestModelDto> GetTest(int id)
    {
        var x = await _context.TestModels.FindAsync(id);
        return _mapper.Map<TestModelDto>(x);
        
    }
}