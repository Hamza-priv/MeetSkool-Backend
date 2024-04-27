using AutoMapper;
using Teachers.Application.DTOS.Response.SubjectDto;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.IRepository;

namespace Teachers.Application.Services.Implementation;

public class SubjectServices : ISubjectServices
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;

    public SubjectServices(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<GetSubjectResponseDto?> GetSubject(Guid subjectId)
    {
        try
        {
            if (subjectId == Guid.Empty) return null;
            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            return subject is not null ? _mapper.Map<GetSubjectResponseDto>(subject) : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}