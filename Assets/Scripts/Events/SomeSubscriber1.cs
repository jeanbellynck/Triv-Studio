using UnityEngine;

namespace Events
{
    public sealed class SomeSubscriber1 : MonoBehaviour, IEventHandler<MyEvent1>, IEventHandler<MyEvent2>
    {
        private void Start()
        {
            // SomeSubscriber1 subscribes to 2 events
            EventAggregator.Instance.Subscribe<MyEvent1>(this);
            EventAggregator.Instance.Subscribe<MyEvent2>(this);
        }

        private void OnDestroy()
        {
            // Cleanup to avoid any memory leaks
            EventAggregator.Instance.Unsubscribe<MyEvent1>(this);
            EventAggregator.Instance.Unsubscribe<MyEvent2>(this);
        }

        public void Handle(MyEvent1 value)
        {
            Debug.Log("MyEvent1 handled");
        }

        public void Handle(MyEvent2 value)
        {
            Debug.Log("MyEvent2 handled");
        }
    }
}