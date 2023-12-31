﻿using BusinessObjects.DTOs;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IUserRepository
    {
        List<UserDTO> GetAllUsers();

        UserDTO GetUserDTOById(int id);

        TblUser GetUserByID(int id);
        
        void AddNew(TblUser user);

        void Update(TblUser user);

        void Delete(int id);

        TblUser checkLogin(string userName,  string password);  
    }
}
