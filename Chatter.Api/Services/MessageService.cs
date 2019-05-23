using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chatter.Api.Entities;
using Chatter.Api.Repository;

namespace Chatter.Api.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository _repository;

        public MessageService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(Message message)
        {
            try
            {
                await _repository.Insert(message, CancellationToken.None);
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public Task<IEnumerable<Message>> Get(int page = 1, int pageSize = 10)
        {
            return Task.FromResult(_repository.All<Message>().Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable());
        }

        public Task<Message> Get(Guid requestId)
        {
            return Task.FromResult(_repository.Find<Message>(x => x.RequestId.Equals(requestId)));
        }
    }
}
