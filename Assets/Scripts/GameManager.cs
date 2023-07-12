using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float StressGauge;
    public float StressGaugeFillingSpeed = 0.05f;
    public int NumberOfPassangers;
    public int NumberOfNotPaidPassangers;
    public GameObject SmokeButton;
    public GameObject GetPaidButton;

    // Update is called once per frame
    void Update()
    {
        FillSmokeGauge();
        ShowButtons();
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

    
}
