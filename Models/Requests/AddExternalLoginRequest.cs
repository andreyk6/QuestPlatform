using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Models.Requests
{
    public class AddExternalLoginRequest
    {
        public string UserId { get; set; }
        public string ExternalAccessToken { get; set; }

        public UserLoginInfo LoginInfo { get; set; }
    }
}
