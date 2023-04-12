using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Models.Poll
{
    public class CreateUserAnswerModelOneOption : CreateUserAnswerModelAbstract
    {
        [Required]
        public int AnswerId { get; set; }
    }
}
