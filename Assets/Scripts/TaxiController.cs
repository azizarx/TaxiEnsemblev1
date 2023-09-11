using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TaxiController : MonoBehaviour
{
    public Vector3 road;
    public HoldButton HoldButton;
    public Animator animator;
    public Transform[] path; // The path the car will follow
    public float MaxSpeed = 10f; // The MaxSpeed of the car
    public float Speed = 10f; // The MaxSpeed of the car
    public float Acceleration = 1f;
    public float Deceleration = 1f;
    public LifeCounter lifeCounter;
    Vector3 forwardDirection;
    private void Start()
    {
        Time.timeScale = 1;
        road = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>();
        //forwardDirection = transform.forward; // Get the forward direction of the car
    }
    private void Update()
    {
        MoveForward();
        Accelerate();
        movement();
        //ChangePath();
     
    }
    void Accelerate()
    {
        if (HoldButton.isHeld)
        {
            Speed = Mathf.MoveTowards(Speed, 0f, Deceleration * Time.deltaTime);
            //Speed -= Deceleration * Time.deltaTime;
        }
        else if (Speed < MaxSpeed) 
        {
            Speed = Mathf.MoveTowards(Speed, MaxSpeed, Acceleration * Time.deltaTime);
        }
    }

    private void MoveForward()
    {
        Vector3 movement = transform.forward * Speed * Time.deltaTime; // Calculate the movement vector

        transform.position += movement; // Move the car forward
    }
    private void ChangePath()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x == path[2].position.x)
            {
                animator.SetTrigger("ChangePathLeftTrigger");
                Vector3 temp = new Vector3(path[1].position.x, transform.position.y, transform.position.z);
                transform.position = temp;
                
            }
            else if (transform.position.x == path[1].position.x)
            {
                Vector3 temp = new Vector3(path[0].position.x, transform.position.y, transform.position.z);
                transform.position = temp;
            }
            else if (transform.position.x == path[0].position.x)
            {
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x == path[0].position.x)
            {
                Vector3 temp = new Vector3(path[1].position.x, transform.position.y, transform.position.z);
                transform.position = temp;
            }
            else if (transform.position.x == path[1].position.x)
            {
                Vector3 temp = new Vector3(path[2].position.x, transform.position.y, transform.position.z);
                transform.position = temp;
            }
            else if (transform.position.x == path[2].position.x)
            {
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NormalCar"))
        {
            lifeCounter.LoseLife();
            Debug.Log("speed = 1");
            Speed = 0;
            
        }
    }


    //public float MaxSpeed;
    public int curPos = 0;
    //public float horizontal;
    void movement()//the movement of the vecle 
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //horizontal = -1;
            if (curPos > -1)  { curPos--; }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //horizontal = 1;
            if (curPos < 1)  { curPos++; }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[curPos+1].position.x, transform.position.y, transform.position.z), Speed * Time.deltaTime);

        //else horizontal = 0;
        /*
        if (curPos != 0 && horizontal != 0 && Math.Sign(curPos) != Math.Sign(horizontal)) 
        {
            curPos = 0;
        }
        else if (curPos == 0 && horizontal != 0)
        {
            curPos = horizontal * 4;
            curPos= path[0].position.x;
        }
        */
    }

    public void RightButton()
    {
        if (curPos < 1) { curPos++; }
    }
    public void LeftButton()
    {
        if (curPos > -1) { curPos--; }
    }
}

