using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PollApp.Application.Models.Poll;
using PollApp.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PollApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _pollService.GetPoll(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePollModel createPollModel)
        {
            await _pollService.CreatePoll(createPollModel);
            return Ok();
        }

        [HttpPost("Vote")]
        public async Task<ActionResult> Vote(CreateUserAnswerModelAbstract model)
        {
            await _pollService.CreateUserAnswer(model);
            return Ok();
        }


    }
}
