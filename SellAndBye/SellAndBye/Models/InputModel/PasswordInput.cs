using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBye.Models.InputModel
{
    public class PasswordInput
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}