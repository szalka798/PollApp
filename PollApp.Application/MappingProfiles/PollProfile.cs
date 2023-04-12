using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PollApp.Application.Models.Poll;
using PollApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.MappingProfiles
{
    public class PollProfile : Profile
    {
        public PollProfile()
        {
            CreateMap<CreateUserAnswerModelOneOption, UserAnswer>();
            CreateMap<CreateUserAnswerModelMultipleOptions, UserAnswer>();

            CreateMap<Poll, PollResponseModel>();
            CreateMap<Answer, AnswerResponseModel>();

            CreateMap<CreatePollModel, Poll>();
            CreateMap<CreateAnswerModel, Answer>();





        }
    }
}
