using System;

namespace Chatter.Api.Models
{
    public class SendMessageModel
    {
        public Guid RequestId { get; private set; }
        public string Text { get; set; }
        public string UserId { get; set; }

        public SendMessageModel()
        {
            RequestId = Guid.NewGuid();
        }
    }
}
