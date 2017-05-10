using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Requests
{
    public class SetPasswordRequest
    {
        public SetPasswordRequest()
        {
            
        }

        public SetPasswordRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
