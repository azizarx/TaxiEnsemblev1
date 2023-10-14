using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoadGenerator : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // Prefab of the road segment
    public int numSegmentsOnScreen = 5; // Number of road segments to keep on screen
    public float segmentLength = 10.0f; // Length of each road segment
    public Transform player; // Reference to the player's transform
    private List<GameObject> roadSegments = new List<GameObject>();
    private float spawnZ = 50f;





    private void Start()
    {
        // Spawn initial road segments
        for (int i = 0; i < numSegmentsOnScreen; i++)
        {
            SpawnRoadSegment();
        }
    }

    private void Update()
    {
        // Check if player has moved past the first segment
        if (player.position.z - numSegmentsOnScreen * segmentLength > spawnZ)
        {
            SpawnRoadSegment();
            DeleteRoadSegment();
        }
    }

    private void SpawnRoadSegment()
    {
        GameObject segment = Instantiate(roadSegmentPrefab, transform.forward * spawnZ, transform.rotation);
        roadSegments.Add(segment);
        spawnZ += segmentLength;
    }

    private void DeleteRoadSegment()
    {
        Destroy(roadSegments[0]);
        roadSegments.RemoveAt(0);
    }
}