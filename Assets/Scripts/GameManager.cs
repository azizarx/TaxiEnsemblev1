using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject taxi;
    public GameObject stopZone;
    public GameObject stopZones;


    public float StressGauge;
    public float StressGaugeFillingSpeed = 0.05f;
    public int numberOfPassangers = 0;
    //public int NumberOfPassangers;
    public int NumberOfNotPaidPassangers;
    public GameObject SmokeButton;
    public GameObject GetPaidButton;

    [Tooltip("lowest possible time to spawn a clinet 'zone'")] public int mintime;
    [Tooltip("highest possible time to spawn a clinet 'zone'")] public int maxtime;
    [Tooltip("lowest possible distance from taxi to spawn a clinet 'zone'")] public int minDistance;
    [Tooltip("highest possible distance from taxi to spawn a clinet 'zone'")] public int maxDistance;
    public float time;//client zone spawning time
    public int side;// client zone spawning side (left or right)
    private void Awake()
    {
        //create a random time
        time = Random.Range(mintime, maxtime);//random time to spawn a client
        side = Random.Range(0, 2) == 0 ? -1 : 1;// random var for spawning the client on the left or right side
    }
        
    
    void Update()
    {
        FillSmokeGauge();
        ShowButtons();

        ClientSpawner();
    }

    void FillSmokeGauge()
    {
        if (StressGauge < 100)
        {
            StressGauge += StressGaugeFillingSpeed * Time.deltaTime;
        }
    }

    void ShowButtons()
    {
        if(StressGauge > 50f)
        {
            //make smoking button visible
            SmokeButton.SetActive(true);
        }
        else
        {
            //make smoking button not visible
            SmokeButton.SetActive(false);

        }
        if (PassengerIsPaying)
        {
            //make smoking button visible
            GetPaidButton.SetActive(true);
        }
        else
        {
            //make smoking button not visible
            GetPaidButton.SetActive(false);

        }

    }

    bool PassengerIsPaying;
    void Passangers()
    {
        //track the number of passangers to 9 max and if the number of not payed passangers is > 0 then put a random timer between 5 and 10 seconds to show the money button 
        //when money button is pressed decreese payed passangers by 1
        //passangers will appear in the map to get in the vehicle and if number of passangers is >0 dismount passangers that have paid in random locations
    }

    public void Smoke()
    {
        StressGauge -= 50f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void ClientSpawner()
    {
        //wait for the time and get a random bool true or false (right or left)
        if (time > 0f)
        {
            time -= Time.deltaTime;    
        }
        //if (positionAnchor + Distance < taxi.transform.position.z && time < 0)
        else
        {
            float Distance = Random.Range( minDistance,  maxDistance);// random distance to spawn a client
            float positionAnchor = taxi.transform.position.z;//the taxi z position is saved for later calculation in distance

            GameObject tempZone = Instantiate(stopZone, new Vector3(8 * side, 0.5f, taxi.transform.position.z + Distance), Quaternion.identity);
            tempZone.transform.parent = stopZones.transform;

            time = Random.Range(0f, 10f);//random time to spawn a client
            side = Random.Range(0, 2) == 0 ? -1 : 1;//rest radom side to spawn at
        }
    }
    

}
