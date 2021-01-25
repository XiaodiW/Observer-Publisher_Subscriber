using System;

namespace Script {

    public interface IMessageHandler {
        void SubscribeTo(String messageType, Action<object> listener);
        void UnSubscribeFrom(String messageType, Action<object> Listener);
        void Publish(String messageType, object message);
    }

}