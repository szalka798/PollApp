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


    public interface ICheckAnswerFactory
    {
        public List<Answer> CheckExistAnswer(CreateUserAnswerModelAbstract createUserAnswerModelAbstract, List<int> answers);
    }

    public class CheckAnswerFactory
    {
        private readonly DatabaseContext _databaseContext;
        public CheckAnswerFactory(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public ICheckAnswerFactory GetCheckAnswerFactory(CreateUserAnswerModelAbstract createUserAnswerModelAbstract)
        {
            switch (createUserAnswerModelAbstract)
            {
                case CreateUserAnswerModelMultipleOptions:
                    return new MultipleAnswersCheck(_databaseContext);
                case CreateUserAnswerModelOneOption:
                    return new OneAnswerCheck(_databaseContext);
                default: 
                    throw new ArgumentException();
            }

        }



    }
}
