﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessDefinitionLibrary.Data_Access_Models;

namespace DataAccessDefinitionLibrary.DAO_Interfaces
{
    public interface IWebUserDataAccess
    {
        Task<WebUser> InsertWebUserAsync(WebUser webUser);
        Task<WebUser> GetWebUserByUsernameAsync(string username);
        Task<WebUser> GetWebUserByIdAsync(int id);
        Task<IEnumerable<WebUser>> GetAllWebUsersAsync();
        Task UpdateWebUserAsync(WebUser webUser);
        Task DeleteWebUserAsync(int webUserId);
    }
}
