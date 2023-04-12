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
    public class MultipleAnswersCheck : ICheckAnswerFactory
    {
        private readonly DatabaseContext _databaseContext;
        public MultipleAnswersCheck(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Answer> CheckExistAnswer(CreateUserAnswerModelAbstract createUserAnswerModelAbstract, List<int> answers)
        {
            var useranswers = (CreateUserAnswerModelMultipleOptions)createUserAnswerModelAbstract;

            var intersection = answers.Intersect(useranswers.AnswersId);
            if (!(intersection.Count() == useranswers.AnswersId.Count())) return null;

            return _databaseContext.Answers.Where(x => useranswers.AnswersId.Contains(x.Id)).ToList();


        }

    }
}
