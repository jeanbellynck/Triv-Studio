using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField, Range(0,1)]
    private float spawnLikelyhood = 1;

    public List<Vector3> spawnVectors = new List<Vector3>();

    public bool maybeSpawnEnemyEvent(Vector3 position, GameObject parent = null)
    {
        float a = Random.Range(0f,1f);
        if (a < spawnLikelyhood)
        {
            spawnEnemy(position, parent);
            return true;
        }

        return false;
    }
    public GameObject spawnEnemy(Vector3 position, GameObject parent = null)
    {
        if (parent != null) return Instantiate(enemy, new Vector3(parent.transform.position.x + position.x, parent.transform.position.y + position.y, parent.transform.position.z + position.z), Quaternion.identity, parent.transform);
        return Instantiate(enemy, position, Quaternion.identity);
        
    }
}