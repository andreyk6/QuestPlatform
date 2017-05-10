using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class UserRegistrationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public UserRegistrationResponse()
        {
            
        }

        public UserRegistrationResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
