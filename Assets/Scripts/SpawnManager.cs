using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] float objectsMinSpawnTime = 0;
    [SerializeField] float objectsMaxSpawnTime = 0;

    void Start()
    {
        StartCoroutine(CreateObjects());
    }


    IEnumerator CreateObjects()
    {
        while (true)
        {
            float spawnTime = Random.Range(objectsMinSpawnTime, objectsMaxSpawnTime);
            int index = Random.Range(0, obstacles.Count);

            yield return new WaitForSeconds(spawnTime);

            Instantiate(obstacles[index]);
        }
    }
}
