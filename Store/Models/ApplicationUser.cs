using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ApplicationUser
    {
        public virtual IQueryable<Game> Games { get; set; }

        public virtual IQueryable<Quiz> Quizzes { get; set; }
    }
}
