using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Object[] prefabs;
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
}
