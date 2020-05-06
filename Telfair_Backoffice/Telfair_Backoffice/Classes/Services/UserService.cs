using Microsoft.AspNetCore.Mvc;
using SAIM.Core.BusinessObjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telfair_Backend.Classes.DAO;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Classes.Services
{
    public class UserService
    {
        public UserModel GetUser(string username, string password)
        {
            try
            {
                return new EmployeeDAO().GetUserMySchool(username, password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
