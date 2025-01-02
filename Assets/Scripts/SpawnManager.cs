using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] float minSpawnTime = 2.0f;
    [SerializeField] float maxSpawnTime = 4.0f;

    void Start()
    {
        StartCoroutine(CreateObstacle());
    }


    IEnumerator CreateObstacle()
    {
        while (true)
        {
            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            int index = Random.Range(0, prefabs.Count);

            yield return new WaitForSeconds(spawnTime);

            Instantiate(prefabs[index]);
        }
    }
}
