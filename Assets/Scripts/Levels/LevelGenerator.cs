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
        [SerializeField] 
        private GameObject _player;

        [SerializeField]
        [Tooltip("Stops spawning random segments after the player has traveled a given distance")]
        private float _playerDistance;

        [SerializeField] 
        private GameObject _startSegment;
        
        [SerializeField]
        private Transform _startSegmentPosition;

        [SerializeField] 
        private GameObject _endSegment;

        [Tooltip("List of segments that get randomly spawned")]
        [SerializeField] 
        private List<GameObject> _segments = new();

        [SerializeField]
        private float _segmentWidth;

        [SerializeField] 
        private float _segmentXOffset;

        private Vector3 _lastSpawnPosition;
        private float _halfCameraWidth;
        private bool _endSegmentSpawned;

        private void Awake()
        {
            _lastSpawnPosition = _startSegmentPosition.position;
            Instantiate(_startSegment, _lastSpawnPosition, Quaternion.identity);
            _halfCameraWidth = Camera.main.GetDimensions().Width / 2;
        }
        
        private void Start()
        {
            InitializeSegments();
        }
        
        private void Update()
        {
            if (_endSegmentSpawned)
            {
                return;
            }

            var distance = _player.GetComponent<playerMovement>().Distance;
            
            if (distance > _playerDistance || _segments.Count == 0)
            {
                SpawnSegment(_endSegment);
                _endSegmentSpawned = true;

                return;
            }

            if (CanSpawnRandomSegment())
            {
                SpawnRandomSegment();
            }
        }

        private void InitializeSegments()
        {
            while (_lastSpawnPosition.x <= _halfCameraWidth)
            {
               SpawnRandomSegment();
            }
        }

        private bool CanSpawnRandomSegment()
        {
            var x1 = Camera.main.transform.position.x + _halfCameraWidth;
            var x2 = _lastSpawnPosition.x;

            return Mathf.Abs(x2 - x1) < _segmentWidth;
        }

        private void SpawnRandomSegment()
        {
            var index = Random.Range(0, _segments.Count);
            var segment = _segments[index];
            SpawnSegment(segment);
        }

        private void SpawnSegment(GameObject segment)
        {
            _lastSpawnPosition += new Vector3(_segmentWidth + _segmentXOffset, 0, 0);
            Instantiate(segment, _lastSpawnPosition, Quaternion.identity);
        }
    }
}
