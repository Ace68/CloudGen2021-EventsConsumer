using System;
using FourSolid.Athena.Core;

namespace CloudGenEventsConsumer.Shared.CustomTypes
{
    public sealed class DeviceId : DomainId
    {
        public DeviceId(Guid value) : base(value)
        {
        }
    }
}