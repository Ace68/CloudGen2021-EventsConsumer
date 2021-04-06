using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class StreamType : CustomTypeString<StreamType>
    {
        public StreamType(string value) : base(value)
        {
        }
    }
}