using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual IQueryable<Option> Options { get; set; }
    }
}
