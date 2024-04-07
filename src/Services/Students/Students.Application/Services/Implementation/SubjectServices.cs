using AutoMapper;
using Students.Application.DTOS.Response.SubjectDto;
using Students.Application.Services.Interfaces;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class SubjectServices : ISubjectServices
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;

    public SubjectServices(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<GetSubjectResponseDto?> GetSubject(string subjectId)
    {
        try
        {
            if (subjectId.Length <= 0) return null;
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