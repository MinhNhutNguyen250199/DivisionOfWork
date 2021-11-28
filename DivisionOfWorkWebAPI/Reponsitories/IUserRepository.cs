
using DivisionOfWorkWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisionOfWorkWebAPI.Reponsitories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();
    }
}
