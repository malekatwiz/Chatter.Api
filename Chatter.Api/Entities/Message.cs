using MongoDB.Bson;
using System;

namespace Chatter.Api.Entities
{
    public class Message
    {
        public Message()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public ObjectId Id { get; private set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedOn { get; private set; }
    }
}
