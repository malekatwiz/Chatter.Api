using Chatter.Api.Entities;
using Chatter.Api.Models;
using Chatter.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        public IActionResult Index([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return new JsonResult(_messageService.Get(page, pageSize))
            { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody]SendMessageModel model)
        {
            if (IsSendMessageModelValid(model))
            {
                if (await _messageService.Create(new Message(model.UserId, model.Text, model.RequestId)))
                {
                    return Ok(_messageService.Get(model.RequestId));
                }
            }
            else
            {
                return BadRequest();
            }

            return new ObjectResult(null) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }

        private bool IsSendMessageModelValid(SendMessageModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.UserId) || string.IsNullOrEmpty(model.Text))
            {
                return false;
            }
            return true;
        }
    }
}