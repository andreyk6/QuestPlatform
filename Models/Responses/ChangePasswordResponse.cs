using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class ChangePasswordResponse
    {
        public ChangePasswordResponse()
        {
            
        }

        public ChangePasswordResponse(bool succeded, string message)
        {
            Succeded = succeded;
            Message = message;
        }

        public bool Succeded { get; set; }
        public string Message { get; set; }

        public static ChangePasswordResponse Fail(string message)
        {
            return new ChangePasswordResponse(false, message);
        }

        public static ChangePasswordResponse Success()
        {
            return Success("Confirmed!");
        }

        public static ChangePasswordResponse Success(string message)
        {
            return new ChangePasswordResponse(true, message);
        }
    }
}
