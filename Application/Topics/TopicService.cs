using Application.Data.DataBaseContext;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics
{
    public class TopicService : ITopicService
    {
        private readonly ILogger<TopicService> _logger;
        private readonly IApplicationDbContext dbContext;

        public TopicService(IApplicationDbContext dbContext, ILogger<TopicService> logger)
        {
            this.dbContext = dbContext;
            this._logger = logger;
        }


        public Task<Topic> CreateTopicAsync(TopicId topicRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTopicAsync(TopicId id)
        {
            throw new NotImplementedException();
        }
        public Task<Topic> GetTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Topic>> GetTopicsAsync()
        {
            var topic = await dbContext.Topics
                .AsNoTracking()
                .ToListAsync();
            return topic;
        }

        public Task<Topic> UpdateTopicAsync(TopicId id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
