using PollApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Core.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public List<Answer> Answers { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
