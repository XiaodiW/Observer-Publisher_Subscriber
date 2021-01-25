using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Script {
    
    public class Broker : IMessageHandler{
        // private readonly Dictionary<String, Action<object>> subscribers = new Dictionary<string, Action<object>>();
        public Dictionary<Type, object> subscribersGeniric = new Dictionary<Type, object>() ;

        /*public void SubscribeTo(string messageType, Action<object> listener) {
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
        }*/

        public void SubscribeTo<T>(Action<T> callback) {
            if (this.subscribersGeniric.TryGetValue(typeof(T), out var subscribersGeniric)) {
                callback = (subscribersGeniric as Action<T>) + callback;
            }

            this.subscribersGeniric[typeof(T)] = callback;
        }

        public void UnSubscribeTo<T>(Action<T> callback) {
            if (this.subscribersGeniric.TryGetValue(typeof(T), out var subscribers)) {
                callback = (subscribers as Action<T>) - callback;
                if (callback != null)
                    this.subscribersGeniric[typeof(T)] = callback;
                else
                    this.subscribersGeniric.Remove(typeof(T));
            }
        }

        public void Publish<T>(T message) {
            if (this.subscribersGeniric.TryGetValue(typeof(T), out var subscribers)) {
                (subscribers as Action<T>).Invoke(message);
            }
        }
    }

}