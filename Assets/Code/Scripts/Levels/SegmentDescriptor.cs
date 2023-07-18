using UnityEngine;

/// <summary>
/// Describes a level segment.
/// </summary>
public sealed class SegmentDescriptor : MonoBehaviour
{
    [SerializeField]
    private float _segmentWidth;

    private float _verticalDifference;
    
    /// <summary>
    /// The width of the segment.
    /// </summary>
    public float SegmentWidth => _segmentWidth;
    
}
