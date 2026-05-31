using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public record UpdateTopicDto(
        string Title,
        string Summary,
        string TopicType,
        LocationDto Location,
        DateTime EventStart);
}
