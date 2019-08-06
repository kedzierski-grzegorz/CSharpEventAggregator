using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public static class EventAggregator
    {
        private static Dictionary<Type, object> _events = new Dictionary<Type, object>();

        public static T GetEvent<T>() where T : new()
        {
            if (_events.ContainsKey(typeof(T)))
            {
                return (T)_events[typeof(T)];
            }
            else
            {
                var aggregatedEvent = new T();
                _events.Add(typeof(T), aggregatedEvent);
                return aggregatedEvent;
            }
        }
    }
}
