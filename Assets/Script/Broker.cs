using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Script {
    
    public class Broker : IMessageHandler{
        private readonly Dictionary<String, Action<object>> subscribers = new Dictionary<string, Action<object>>();

        public void SubscribeTo(string messageType, Action<object> listener) {
            if(subscribers.Count == 0 || !subscribers.Keys.Contains(messageType)) 
                subscribers.Add(messageType, listener);
            else {
                var temp = subscribers[messageType];
                temp += listener;
                subscribers[messageType] = temp;
            }
        }

        public void UnSubscribeFrom(string messageType, Action<object> Listener) {
            subscribers.Remove(messageType);
        }

        public void Publish(string messageType, object message) {
            subscribers[messageType]?.Invoke(message);
        }
    }

}