using AutoMapper;
using DataLib;
using DataLib.DTOs;
using DbAccessLib.DataAccess;

namespace DbAccessLib.Data;

public class DatabaseRepository : IDatabaseRepository<TestModelDto>
{
    private readonly DatabaseDbContext _context;
    private readonly IMapper _mapper;

    public DatabaseRepository(DatabaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TestModelDto> Get(int id)
    {
        var x = await _context.TestModels.FindAsync(id);
        return _mapper.Map<TestModelDto>(x);
        
    }
}