using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopZoneScript : MonoBehaviour
{

    bool inZone;
    public GameObject taxi;
    float speed;
    public GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
        taxi = GameObject.Find("Taxi");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(inZone)
        {
            speed = taxi.GetComponent<TaxiController>().Speed;
            if (speed<0.1f)
            {
                Debug.Log("client in");
                gameManager.NumberOfPassangers++;
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
