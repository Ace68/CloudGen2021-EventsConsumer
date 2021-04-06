using System;
using CloudGenEventsConsumer.Shared.Abstracts;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class CommunicationDate : CustomTypeDate<CommunicationDate>
    {
        public CommunicationDate(DateTime value) : base(value)
        {
        }
    }
}