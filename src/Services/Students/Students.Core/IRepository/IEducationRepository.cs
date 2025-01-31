﻿using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface IEducationRepository : IGenericRepository<Education>
{ 
    Task<Education?> GetStudentEducation(string studentId);
}