using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnObjectsByDistance : MonoBehaviour
{
    public Transform[] spawnVertPositions;
    public GameObject[] listOfObjects;
    public float spawnDistance = 50f;
    public float lastSpawnHorPosition;
    public Vector3 spawnRotation = Vector3.zero;
    public float spawnDistanceFromSpawner;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > lastSpawnHorPosition + spawnDistance) 
        {
            Vector3 spawnPosition = new Vector3(spawnVertPositions[Random.Range(0, spawnVertPositions.Length)].position.x, 1.5f, transform.position.z + spawnDistanceFromSpawner);// + playerCar.forward * spawnDistance.position.z;
            GameObject newCar = Instantiate(listOfObjects[Random.Range(0, listOfObjects.Length)], spawnPosition, Quaternion.Euler(spawnRotation));
            lastSpawnHorPosition = transform.position.z;
        }
    }
}
