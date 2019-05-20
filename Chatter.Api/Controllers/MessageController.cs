using Chatter.Api.Entities;
using Chatter.Api.Models;
using Chatter.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chatter.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult(_messageService.Get());
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody]SendMessageModel model)
        {
            await _messageService.Create(new Message
            {
                Text = model.Text,
                UserId = model.UserId
            });

            return Ok();
        }
    }
}