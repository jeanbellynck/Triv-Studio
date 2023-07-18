using System.Collections.Generic;
using Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    /// <summary>
    /// Generates a level with random level segments.
    /// </summary>
    public sealed class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _startSegment;
        [SerializeField] private Vector3 _startSegmentPosition;

        [Tooltip("List of segments that get randomly spawned")]
        [SerializeField] private List<GameObject> _segments = new();

        [Tooltip("Visible gap between two spawned segments")]
        [SerializeField] private float _segmentXOffset;

        [SerializeField] private float upperSpawnLimit = 1000f;
        [SerializeField] private float lowerSpawnLimit = -10f;

        private Vector3 _lastSpawnPosition;
        private Vector3 _lastEndPosition;
        private float _halfCameraWidth;
        private float _currentSegmentWidth;

        private string END_POSITION_NAME = "EndPosition";

        private void Awake()
        {
            _lastSpawnPosition = _startSegmentPosition;
            _lastEndPosition = _startSegmentPosition + _startSegment.transform.Find(END_POSITION_NAME).transform.position;
            _halfCameraWidth = Camera.main.GetDimensions().Width / 2;
        }
        
        private void Start()
        {
            InitializeSegments();
        }
        
        private void Update()
        {
            if (CanSpawnRandomSegment())
            {
                SpawnRandomSegment();
            }
        }

        private void InitializeSegments()
        {
            Instantiate(_startSegment, _startSegmentPosition, Quaternion.identity);
            _currentSegmentWidth = _startSegment.GetComponent<SegmentDescriptor>().SegmentWidth;

            while (_lastSpawnPosition.x <= _halfCameraWidth)
            {
               SpawnRandomSegment();
            }
        }

        private bool CanSpawnRandomSegment() 
        {
            var x1 = Camera.main.transform.position.x + _halfCameraWidth;
            var x2 = _lastSpawnPosition.x;

            return Mathf.Abs(x2 - x1) < _currentSegmentWidth;
        }

        private void SpawnRandomSegment()
        {
            GameObject segment = null;
            var tries = 0;
            do {
                segment = _segments[Random.Range(0, _segments.Count)];
                tries++;
                if ( 100 < tries) 
                {
                    throw new System.Exception();
                }
            } while (!checkIfSegmentIsOkay(segment));
            
            SpawnSegment(segment);
        }

        private bool checkIfSegmentIsOkay(GameObject segment)
        {
            //checks if the new height is within bounds
            var predictedEndPosition = _lastEndPosition.y + segment.transform.Find("EndPosition").transform.position.y;
            return predictedEndPosition < upperSpawnLimit && lowerSpawnLimit < predictedEndPosition ;
            
        }

        private void SpawnSegment(GameObject segment)
        {
            // determine new Spawn Position
            //Vector3 newSpawnPosition = _lastSpawnPosition + new Vector3(_currentSegmentWidth + _segmentXOffset, 0, 0);
            Vector3 newSpawnPosition = _lastEndPosition;

            // Instantiate new Segment
            GameObject spawnedSegment = Instantiate(segment, newSpawnPosition, Quaternion.identity);

            //update global variables
            _lastSpawnPosition = spawnedSegment.transform.position;
            _currentSegmentWidth = spawnedSegment.GetComponent<SegmentDescriptor>().SegmentWidth;
            _lastEndPosition = spawnedSegment.transform.Find(END_POSITION_NAME).transform.position;
        }
    }
}
