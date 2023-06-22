using System.Collections;
using UnityEngine;

namespace Events
{
    public sealed class SomePublisher : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(PublishEvent1());
            StartCoroutine(PublishEvent2());
        }

        IEnumerator PublishEvent1()
        {
            // Publish event every 10 seconds
            while (true)
            {
                EventAggregator.Instance.Publish(new MyEvent1("Foobar", 42));

                yield return new WaitForSeconds(10);
            }
        }

        IEnumerator PublishEvent2()
        {
            // Publish event every 20 seconds
            while (true)
            {
                EventAggregator.Instance.Publish(new MyEvent2(100.0f));

                yield return new WaitForSeconds(20);
            }
        }
    }
}