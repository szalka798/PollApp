using PollApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.Poll
{
    public class AnswerResponseModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
