using PollApp.Core.Entities;
using PollApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.Poll
{
    public class PollResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<AnswerResponseModel> Answers { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
