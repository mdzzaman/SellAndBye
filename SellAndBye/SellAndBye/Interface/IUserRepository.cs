using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SellAndBye.DataModel;
using SellAndBye.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBye.Interface
{
    public interface IUserRepository
    {
        //IEnumerable<User> GetAllVehicles();
        bool UserCheckByEmailAndPassword(string email, string password);
        bool UserEmailCheck(string email);
        User UserInfoByEmail(string email);
        bool Update(string objectId, User p);
        bool ImageUpdate(string objectId, string p);
        User Add(User p);
        bool Delete(string objectId);
    }
}
