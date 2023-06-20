using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public interface IPollService
    {
        public Task CreateUserAnswer(CreateUserAnswerModelAbstract createUserAnswerModelAbstract);
        public Task<PollResponseModel> GetPoll(int pollid);
        public Task CreatePoll(CreatePollModel createPollModel);
    }

    public class PollService : IPollService
    {

        private readonly DatabaseContext _databaseContext;
        private readonly CheckAnswerFactory _checkAnswerFactory;
        private readonly IMapper _mapper;

        public PollService(DatabaseContext databaseContext, CheckAnswerFactory checkAnswerFactory, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _checkAnswerFactory = checkAnswerFactory;
            _mapper = mapper;
        }

        public async Task CreatePoll(CreatePollModel createPollModel)
        {
            var map = _mapper.Map<Poll>(createPollModel);
            await _databaseContext.AddAsync(map);
            await _databaseContext.SaveChangesAsync();
        }


        public async Task<PollResponseModel> GetPoll(int pollid)
        {
            var poll = await _databaseContext.Polls
                .Include(x => x.Answers)
                .FirstOrDefaultAsync(x => x.Id == pollid);

            if (poll == null) throw new Exception();

            return _mapper.Map<PollResponseModel>(poll);
        }


        public async Task CreateUserAnswer(CreateUserAnswerModelAbstract createUserAnswerModelAbstract)
        {

            var poll = _databaseContext.Polls
                .Include(x => x.Answers)
                .FirstOrDefault(x => x.Id == createUserAnswerModelAbstract.PollId);

            if (poll == null) throw new Exception();

            var answers = _checkAnswerFactory.GetCheckAnswerFactory(createUserAnswerModelAbstract).CheckExistAnswer(createUserAnswerModelAbstract, poll.Answers.Select(x => x.Id).ToList());
            if (answers == null) throw new Exception();

            var userAnswers = new List<UserAnswer>();

            foreach (var answer in answers)
            {
                userAnswers.Add(new UserAnswer() { Answer = answer, CreatedOn = DateTimeOffset.Now});
            }

            await _databaseContext.AddRangeAsync(userAnswers);
            await _databaseContext.SaveChangesAsync();
        }


    }
}
