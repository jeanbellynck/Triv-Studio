using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        public static (float Width, float Height) GetDimensions(this Camera camera)
        {
            var height = 2 * camera.orthographicSize;
            var width = height * camera.aspect;

            return (width, height);
        }
    }
}
