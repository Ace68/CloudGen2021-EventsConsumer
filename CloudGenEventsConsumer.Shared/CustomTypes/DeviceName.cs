using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class DeviceName : CustomTypeString<DeviceName>
    {
        public DeviceName(string value) : base(value)
        {
        }
    }
}