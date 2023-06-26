using UnityEngine;

namespace Extensions
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Calculates the width and height of a given camera in world units.
        /// </summary>
        /// <param name="camera">Some camera</param>
        /// <returns>The width and height of the camera in world units.</returns>
        public static (float Width, float Height) GetDimensions(this Camera camera)
        {
            var height = 2 * camera.orthographicSize;
            var width = height * camera.aspect;

            return (width, height);
        }
    }
}
