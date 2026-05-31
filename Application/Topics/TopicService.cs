using Application.Data.DataBaseContext;
using Application.Dtos;
using Application.Extensions;
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

        public async Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var result = await dbContext.Topics.FindAsync([topicId]);
            if (result is null)
            {
                throw new TopicNotFoundException(id);
            }

            return result.ToTopicResponseDto();
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
            var topic = await dbContext.Topics
                    .AsNoTracking()
                    .ToListAsync();
            return topic.ToTopicResponseDto();

        }

        public Task<Topic> CreateTopicAsync(Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
