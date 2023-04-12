using PollApp.Application.Models.Poll;
using PollApp.Core.Entities;
using PollApp.DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Services
{
    public class OneAnswerCheck : ICheckAnswerFactory
    {
        private readonly DatabaseContext _databaseContext;

        public OneAnswerCheck(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        public List<Answer> CheckExistAnswer(CreateUserAnswerModelAbstract createUserAnswerModelAbstract, List<int> answers)
        {
            var useranswer = (CreateUserAnswerModelOneOption)createUserAnswerModelAbstract;
            if (!answers.Contains(useranswer.AnswerId)) return null;

            return _databaseContext.Answers.Where(x => x.Id == useranswer.AnswerId).ToList();

        }



    }
}
