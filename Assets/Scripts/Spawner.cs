using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /* public Object[] prefabs;
     public float spawnInterval = 1f;
     public float speed = 10f;
     public Transform[] path;
     void Start()
     {

     }

     // Update is called once per frame
     void Update()
     {
         MoveForward();
     }
     private void MoveForward()
     {
         Vector3 forwardDirection = transform.forward; // Get the forward direction of the car
         Vector3 movement = forwardDirection * speed * Time.deltaTime; // Calculate the movement vector

         transform.position += movement; // Move the car forward
     }
     private void spawnCars()
     {

     }*/
    public GameObject[] carPrefabs;  // Array of car prefabs to spawn
    public Transform playerCar;  // Reference to the player car

    public Transform spawnDistance;  // Distance in front of the player car to spawn the new cars
    public float spawnDelay = 1f;  // Delay between each car spawn
    public float yPositionOffset = 1f;  // Y position offset for each spawned car
    public Vector3 spawnRotation = Vector3.zero;  // Rotation of each spawned car
    public float carSpeed = 10f;  // Speed at which the cars move forward

    private void Start()
    {
        StartCoroutine(SpawnCars());
    }

    private System.Collections.IEnumerator SpawnCars()
    {
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            Vector3 spawnPosition = playerCar.position + playerCar.forward * spawnDistance.position.z;
            spawnPosition.y += yPositionOffset;

            foreach (GameObject carPrefab in carPrefabs)
            {
                GameObject newCar = Instantiate(carPrefab, spawnPosition, Quaternion.Euler(spawnRotation));

                // Get the Rigidbody component from the spawned car
                Rigidbody carRigidbody = newCar.GetComponent<Rigidbody>();

                // Disable gravity for the car
                carRigidbody.useGravity = false;

                // Apply forward force to move the car
                carRigidbody.AddForce(0,0,carSpeed, ForceMode.VelocityChange);

                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}
