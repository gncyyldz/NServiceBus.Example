using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class ExampleEvent : IEvent
    {
        public string Message { get; set; }
    }
}
