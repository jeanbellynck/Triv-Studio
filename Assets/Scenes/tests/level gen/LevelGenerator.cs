using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject LVLStart;
    [SerializeField] private List<GameObject> LevelParts;
    [SerializeField] private GameObject player;


    public float spawnDistance = 5f;

    private Vector3 lastEndPosition;

    private void Awake()
    {

        lastEndPosition = LVLStart.transform.Find("EndPosition").position;

    }

    private void Update()
    {
        if(Mathf.Abs(player.transform.position.x - lastEndPosition.x) < spawnDistance)
        {
            //Spawn a level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        GameObject chosenLeveLPart = LevelParts[Random.Range(0, LevelParts.Count)];
        GameObject lastLevel = SpawnLevelPart(lastEndPosition, chosenLeveLPart);
        lastEndPosition = lastLevel.transform.Find("EndPosition").position;
    }

    private GameObject SpawnLevelPart(Vector3 spawnPosition, GameObject levelPart)
    {
        GameObject newLevelPart = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return newLevelPart;  
    }
}
