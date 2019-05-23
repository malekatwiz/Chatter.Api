using MongoDB.Bson;
using System;

namespace Chatter.Api.Entities
{
    public class Message
    {
        public Message(string userId, string text, Guid requestId)
        {
            UserId = userId;
            Text = text;
            RequestId = requestId;
            CreatedOn = DateTime.UtcNow;
        }

        public ObjectId Id { get; private set; }
        public Guid RequestId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; private set; }
    }
}
