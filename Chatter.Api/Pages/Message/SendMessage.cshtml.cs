using Chatter.Api.Models.Message;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chatter.Api.Pages.Message
{
    public class SendMessageModel : PageModel
    {
        [BindProperty]
        public SendModel Input { get; set; }

        public void OnGet()
        {

        }

        public string OnPost()
        {
            return "Message sent";
        }
    }
}