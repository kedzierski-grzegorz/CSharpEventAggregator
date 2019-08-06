using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public abstract class PubSubEvent<TPayload>
    {
        private TPayload _tPayload;

        private List<Action<object>> _subscribers = new List<Action<object>>();

        public void Publish(TPayload tPayload)
        {
            _tPayload = tPayload;
            Execute(tPayload);
        }

        public void Subscribe(Action<object> action)
        {
            if (_subscribers == null)
                _subscribers = new List<Action<object>>();

            _subscribers.Add(action);
            if (_tPayload != null)
                action.Invoke(_tPayload);
        }

        private void Execute(object o)
        {
            foreach (var subscriber in _subscribers)
                subscriber.Invoke(o);
        }
    }
}
