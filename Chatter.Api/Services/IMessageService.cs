using Chatter.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.Api.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> Get(int page = 1, int pageSize = 10);
        Task Create(Message message);
    }
}
