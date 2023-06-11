using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform LVLStart;
    [SerializeField] private List<Transform> LevelParts;
    [SerializeField] private GameObject player;


    public float spawnDistance = 5f;

    private Vector3 lastEndPosition;

    private void Awake()
    {

        lastEndPosition = LVLStart.Find("EndPosition").position;

    }

    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < spawnDistance)
        {
            //Spawn a level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLeveLPart = LevelParts[Random.Range(0, LevelParts.Count)];
        Transform lastLevelTransform = SpawnLevelPart(lastEndPosition, chosenLeveLPart);
        lastEndPosition = lastLevelTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Vector3 spawnPosition, Transform levelPart)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;  
    }
}
