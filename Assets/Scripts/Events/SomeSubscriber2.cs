using UnityEngine;

namespace Events
{
    public sealed class SomeSubscriber2 : MonoBehaviour, IEventHandler<MyEvent1>
    {
        private void Start()
        {
            // SomeSubscriber2 subscribes to 1 event
            EventAggregator.Instance.Subscribe<MyEvent1>(this);
        }

        private void OnDestroy()
        {
            // Cleanup to avoid any memory leaks
            EventAggregator.Instance.Unsubscribe<MyEvent1>(this);
        }

        public void Handle(MyEvent1 value)
        {
            Debug.Log("MyEvent1 handled");
        }
    }
}