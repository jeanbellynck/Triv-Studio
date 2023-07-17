using Extensions;
using UnityEngine;

namespace Levels
{
    /// <summary>
    /// Destroys a level segment if it gets out of view with regards to the left camera border.
    /// </summary>
    public sealed class DestroySegment : MonoBehaviour
    {
     
        private float _segmentWidth;

        private float _halfCameraWidth;
        private float _cameraWidth;

        private bool _destroyed;

        private void Awake()
        {
            _halfCameraWidth = Camera.main.GetDimensions().Width / 2;
            _cameraWidth = Camera.main.GetDimensions().Width;
            _segmentWidth = GetComponent<SegmentDescriptor>().SegmentWidth;

        }

        private void Update()
        {
            if (_destroyed)
            {
                return;
            }

            if (!CanDestroySegment())
            {
                return;
            }

            Destroy(gameObject);
            _destroyed = true;
        }


        private bool CanDestroySegment()
        {
            var x1 = Camera.main.transform.position.x - _cameraWidth - _segmentWidth; // Adding segment width as a buffer
            var x2 = transform.position.x;

            return x2 < x1 && Mathf.Abs(x1 - x2) > _segmentWidth;
        }
    }
}
