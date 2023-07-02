using UnityEngine;

public class TaxiController : MonoBehaviour
{
    public Transform[] path; // The path the car will follow
    public float speed = 10f; // The speed of the car

    private void Update()
    {
        MoveForward();
        ChangePath();
    }

    private void MoveForward()
    {
        Vector3 forwardDirection = transform.forward; // Get the forward direction of the car
        Vector3 movement = forwardDirection * speed * Time.deltaTime; // Calculate the movement vector

        transform.position += movement; // Move the car forward
    }
    private void ChangePath()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x == path[2].position.x)
            {
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
}

