using System.Threading.Tasks;

namespace Perconall.Services.MessageQueueingService
{
    public interface IMessageQueueService
    {
        Task Publish<T>(T obj);
    }
}