using System;

namespace MediaManager.WPF.State.Messengers
{
    public interface IMessenger
    {
        void Register(MessageToken token, Action<object> callback);
        void Send(MessageToken token, object args);
        void Unregister(MessageToken token, Action<object> callback);
    }
}