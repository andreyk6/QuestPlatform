using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestPlatform.Services.Exceptions
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException(Guid id) : base($"Item with id {id} is not exist")
        {
            
        }
    }
}
