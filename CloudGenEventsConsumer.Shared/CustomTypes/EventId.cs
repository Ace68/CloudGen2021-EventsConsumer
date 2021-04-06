using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class EventId : CustomTypeString<EventId>
    {
        public EventId(string value) : base(value)
        {
        }
    }
}