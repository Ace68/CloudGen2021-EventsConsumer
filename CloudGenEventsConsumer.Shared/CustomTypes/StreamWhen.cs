using System;
using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class StreamWhen : CustomTypeDate<StreamWhen>
    {
        public StreamWhen(DateTime value) : base(value)
        {
        }
    }
}