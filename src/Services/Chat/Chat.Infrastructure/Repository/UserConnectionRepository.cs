﻿using Chat.Core.IRepository;
using Chat.Core.Models;
using Chat.Infrastructure.Data;

namespace Chat.Infrastructure.Repository;

public class UserConnectionRepository : GenericRepository<UserConnections>, IUserConnectionRepository
{
    protected UserConnectionRepository(ChatDbContext chatDbContext) : base(chatDbContext)
    {
    }
}