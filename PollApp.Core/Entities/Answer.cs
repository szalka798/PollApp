using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Core.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Poll Poll { get; set; }
        public List<UserAnswer> userAnswers { get; set; }
    }
}
