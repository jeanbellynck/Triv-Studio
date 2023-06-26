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
    public sealed class LevelGeneratorv1 : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField, Range(0, 500)]
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

        public float _renderDistance = 0;


        private Vector3 _lastSpawnPosition;
        private Vector3 _lastEndPosition;
        private GameObject _currentSegment;
        private GameObject _nextSegment;
        private float _halfCameraWidth;

        private void Awake()
        {
            if (_segments.Count == 0)
            {
                throw new InvalidOperationException("No segments are present.");
            }

            _currentSegment = Instantiate(_startSegment, _startSegmentPosition.position, Quaternion.identity);


            _nextSegment = _segments[Random.Range(0, _segments.Count)];
            _halfCameraWidth = Camera.main.GetDimensions().Width / 2;
        }

        private void Start()
        {
            _lastSpawnPosition = _currentSegment.transform.position;
            _lastEndPosition = _currentSegment.transform.Find("EndPosition").position;

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


            SpawnSegment();

        }

        private bool CanSpawnSegment()
        {
            var xCam = Camera.main.transform.position.x + _halfCameraWidth;
            var xEnd = _lastEndPosition.x;

            var calc = (xEnd - _renderDistance) < xCam;
            return calc;
        }

        private void SpawnSegment()
        {

            _currentSegment = Instantiate(_nextSegment, _lastEndPosition, Quaternion.identity);

            //update fields
            _lastSpawnPosition = _currentSegment.transform.position;
            _lastEndPosition = _currentSegment.transform.Find("EndPosition").position;
            _nextSegment = _segments[Random.Range(0, _segments.Count)];
        }
    }
}
