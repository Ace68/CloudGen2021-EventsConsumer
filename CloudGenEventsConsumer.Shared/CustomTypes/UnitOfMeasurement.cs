using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class UnitOfMeasurement : CustomTypeString<UnitOfMeasurement>
    {
        public UnitOfMeasurement(string value) : base(value)
        {
        }
    }
}