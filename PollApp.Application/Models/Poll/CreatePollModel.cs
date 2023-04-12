using PollApp.Core.Entities;
using PollApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.Poll
{
    public class CreatePollModel
    {
        public string Title { get; set; }
        public List<CreateAnswerModel> Answers { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
