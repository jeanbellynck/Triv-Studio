using System;
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

        private void Awake()
        {
            if (_segments.Count == 0)
            {
                throw new InvalidOperationException("No segments are present.");
            }

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
            if (CanSpawnSegment())
            {
                SpawnSegment();
            }
        }

        private void InitializeSegments()
        {
            while (_lastSpawnPosition.x <= _halfCameraWidth)
            {
               SpawnSegment();
            }
        }

        private bool CanSpawnSegment()
        {
            var x1 = Camera.main.transform.position.x + _halfCameraWidth;
            var x2 = _lastSpawnPosition.x;

            return Mathf.Abs(x2 - x1) < _segmentWidth;
        }

        private void SpawnSegment()
        {
            _lastSpawnPosition += new Vector3(_segmentWidth + _segmentXOffset, 0, 0);
            var index = Random.Range(0, _segments.Count);
            var segment = _segments[index];
            Instantiate(segment, _lastSpawnPosition, Quaternion.identity);
        }
    }
}
