using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBye.Interface
{
    interface IPasswordRepository
    {
        bool PassWordCheckByEmail(string email, string password);
        bool Update(string email, string password);
    }
}
