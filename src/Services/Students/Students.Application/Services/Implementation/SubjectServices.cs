using AutoMapper;
using Students.Application.DTOS.Response.SubjectDto;
using Students.Application.ServiceResponse;
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

    public async Task<ServiceResponse<GetSubjectListResponseDto>> GetSearchedSubjects(string? searchTerm)
    {
        var getSearchedSubjectResponse = new ServiceResponse<GetSubjectListResponseDto>()
        {
            Data = new GetSubjectListResponseDto()
        };
        try
        {
            var subjectList = await _subjectRepository.SearchSubjects(searchTerm);
            if (subjectList.Count > 0)
            {
                getSearchedSubjectResponse.Data = _mapper.Map<GetSubjectListResponseDto>(subjectList);
                getSearchedSubjectResponse.Messages.Add("Subjects found");
                return getSearchedSubjectResponse;
            }

            getSearchedSubjectResponse.Error.Add("No subjects found");
            getSearchedSubjectResponse.Success = false;
            return getSearchedSubjectResponse;
        }
        catch (Exception e)
        {
            getSearchedSubjectResponse.Error.Add(e.Message);
            getSearchedSubjectResponse.Success = false;
            return getSearchedSubjectResponse;
        }
    }
}