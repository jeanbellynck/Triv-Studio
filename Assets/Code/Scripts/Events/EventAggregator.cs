using System;
using System.Collections.Generic;
using System.Linq;

namespace Events
{
    /// <summary>
    /// Defines a service for publishing and subscribing to events.
    /// </summary>
    public sealed class EventAggregator
    {
        private static readonly Lazy<EventAggregator> Lazy = new(() => new EventAggregator());

        private readonly Dictionary<Type, List<object>> _subscribersByType = new();
        private readonly object _syncRoot = new();

        /// <summary>
        /// Provides access to the event aggregator instance.
        /// </summary>
        public static EventAggregator Instance => Lazy.Value;

        /// <summary>
        /// Subscribes to an event.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="subscriber">The subscriber</param>
        public void Subscribe<TEvent>(IEventHandler<TEvent> subscriber)
        {
            var type = typeof(TEvent);

            lock (_syncRoot)
            {
                if (!_subscribersByType.ContainsKey(type))
                {
                    _subscribersByType[type] = new List<object>();
                }

                if (_subscribersByType[type].Contains(subscriber))
                {
                    return;
                }

                _subscribersByType[type].Add(subscriber);
            }
        }

        /// <summary>
        /// Unsubscribes from an event.
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="subscriber">The subscriber.</param>
        /// <remarks>The subscriber must manually unsubscribe from the event at some point to avoid any memory leaks.
        /// When used in a MonoBehavior, cleanup can be e.g. done in OnDestroy().</remarks>
        public void Unsubscribe<TEvent>(IEventHandler<TEvent> subscriber)
        {
            var type = typeof(TEvent);

            lock (_syncRoot)
            {
                if (!_subscribersByType.TryGetValue(type, out var subscribers))
                {
                    return;
                }

                if (subscribers.Contains(subscriber))
                {
                    subscribers.Remove(subscriber);
                }
            }
        }

        /// <summary>
        /// Publishes an event.
        /// </summary>
        /// <typeparam name="TEvent">The event.</typeparam>
        /// <param name="args"></param>
        public void Publish<TEvent>(TEvent args)
        {
            var type = typeof(TEvent);

            lock (_syncRoot)
            {
                if (!_subscribersByType.TryGetValue(type, out var allSubscribers))
                {
                    return;
                }

                var subscribers = allSubscribers.OfType<IEventHandler<TEvent>>();

                foreach (var subscriber in subscribers)
                {
                    subscriber.Handle(args);
                }
            }
        }
    }
}