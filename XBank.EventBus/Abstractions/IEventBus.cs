using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.Shared.Abstractions;

namespace XBank.EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish(IEvent @event);
    }
}
