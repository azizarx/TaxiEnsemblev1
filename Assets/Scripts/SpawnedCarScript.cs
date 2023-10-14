using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedCarScript : MonoBehaviour
{
    public GameObject playerTaxi;
    public float carSpeed = 10f;
    public float slowingRatio = 0.8f;


    // Start is called before the first frame update
    void Start()
    {
        slowingRatio = Random.Range(0.2f, 0.7f);
        playerTaxi = FindObjectOfType<TaxiController>().gameObject;
        //carSpeed = playerTaxi.GetComponent<TaxiController>().Speed * slowingRatio;        
        carSpeed = playerTaxi.GetComponent<TaxiController>().MaxSpeed * 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(carSpeed * Time.deltaTime, 0, 0);
    }
}
