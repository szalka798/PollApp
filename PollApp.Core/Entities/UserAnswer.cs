using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Core.Entities
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Answer Answer { get; set; }
    }
}
