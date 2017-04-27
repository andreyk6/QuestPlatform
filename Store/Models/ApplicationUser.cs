using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Store.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IQueryable<Game> Games { get; set; }

        public virtual IQueryable<Quiz> Quizzes { get; set; }
    }
}
