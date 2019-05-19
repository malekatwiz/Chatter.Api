using Chatter.Api.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Chatter.Api.Pages.Message
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<MessageModel> Messages { get; set; }
        public void OnGet()
        {
            Messages = new List<MessageModel>
            {
                new MessageModel{Text = "Hello", By = "Me1"},
                new MessageModel{Text = "Hello", By = "Me2"},
                new MessageModel{Text = "Hello", By = "Me3"},
                new MessageModel{Text = "Hello", By = "Me4"},
                new MessageModel{Text = "Hello", By = "Me5"},
                new MessageModel{Text = "Hello", By = "Me6"},
            };
        }

        public void OnPost()
        {

        }
    }
}