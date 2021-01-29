using System;
using System.Collections.Generic;

namespace MediaManager.WPF.State.Messengers
{
    /// <summary>
    /// Mediator Class that allowing communication between ViewModels.
    /// </summary>
    public class Messenger : IMessenger
    {
        private IDictionary<MessageToken, List<Action<object>>> _dict = new Dictionary<MessageToken, List<Action<object>>>();

        public void Register(MessageToken token, Action<object> callback)
        {
            if (!_dict.ContainsKey(token))
            {
                List<Action<object>> callbacks = new List<Action<object>>();
                callbacks.Add(callback);
                _dict.Add(token, callbacks);
            }
            else
            {
                bool found = false;
                foreach (var savedCallback in _dict[token])
                {
                    if (savedCallback.Method.ToString() == callback.Method.ToString())
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    _dict[token].Add(callback);
                }
            }
        }

        public void Unregister(MessageToken token, Action<object> callback)
        {
            if (_dict.ContainsKey(token))
            {
                _dict[token].Remove(callback);
            }
        }

        public void Send(MessageToken token, object args)
        {
            if (_dict.ContainsKey(token))
            {
                foreach (var savedCallback in _dict[token])
                {
                    savedCallback(args);
                }
            }
        }
    }
}
