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

        public Task Create(Message message)
        {
            return _repository.Insert(message, CancellationToken.None);
        }

        public Task<IEnumerable<Message>> Get(int page = 1, int pageSize = 10)
        {
            return Task.FromResult(_repository.All<Message>().Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable());
        }
    }
}
