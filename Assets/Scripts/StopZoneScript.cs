using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class StopZoneScript : MonoBehaviour
{

    bool inZone;
    public GameObject taxi;
    float speed;
    public GameManager gameManager;

    public float TravelDistance;
    bool spawned;
    public GameObject dropZone;
    public GameObject stopZones;

    // Start is called before the first frame update
    void Start()
    {
        TravelDistance = this.transform.position.z + Random.Range(1000f, 2000f);
        //Debug.Log("start");
        taxi = GameObject.Find("TaxiCar");
        stopZones = GameObject.Find("StopZones(parent)");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(taxi.transform.position.z > this.transform.position.z + 20)
        {
            Destroy(this.gameObject);
        }

        if(inZone)
        {
            speed = taxi.GetComponent<TaxiController>().Speed;
            if (speed<0.1f)
            {
                Debug.Log("client in");
                gameManager.NumberOfPassangers++;

                //create a decend zone here 

                int side = Random.Range(0, 2) == 0 ? -1 : 1;//rest radom side to spawn at
                GameObject tempDropZone = Instantiate(dropZone, new Vector3(8 * side, 0.5f, TravelDistance), Quaternion.identity);
                tempDropZone.transform.parent = stopZones.transform;





                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Taxi"))
        {
            Debug.Log("StopZone");
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Taxi"))
        {
            Debug.Log("StopZone");
            inZone = false;
        }
    }
}
