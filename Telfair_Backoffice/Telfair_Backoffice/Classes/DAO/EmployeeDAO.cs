using SAIM.Core;
using SAIM.Core.BusinessObjects.BusinessLogic;
using SAIM.Core.BusinessObjects.Model;
using SAIM.Core.BusinessObjects.RequestAndResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telfair_Backend.Classes.Entity;
using Telfair_Backend.Classes.Models;
using Telfair_Backend.Classes.Services;

namespace Telfair_Backend.Classes.DAO
{
    public class EmployeeDAO: DAO
    {
        public UserModel GetUserMySchool(string username, string password)
        {
            try
            {
                var request = new UserRequest() { userName = username, password = new Fanafenana().Afeno(password) };
                var logic = new UserBusinessLogic(CoreConnectionString);
                var model = logic.GetUserMySchool(request);
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
