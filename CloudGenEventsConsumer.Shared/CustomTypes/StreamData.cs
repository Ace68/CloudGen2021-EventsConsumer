using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class StreamData : CustomTypeBase<StreamData>
    {
        public readonly byte[] Value;
        
        public StreamData(byte[] value)
        {
            this.Value = value;
        }
    }
}