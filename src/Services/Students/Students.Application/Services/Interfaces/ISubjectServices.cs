﻿using Students.Application.DTOS.Response.SubjectDto;
using Students.Application.ServiceResponse;

namespace Students.Application.Services.Interfaces;

public interface ISubjectServices
{ 
    Task<GetSubjectResponseDto?> GetSubject(string subjectId);
}