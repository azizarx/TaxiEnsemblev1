using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public int numberoflives;
    public GameObject lifePrefab;
    private List<GameObject> lives;
    void Start()
    {
        lives = new List<GameObject>();
        for (int i = 0; i < numberoflives; i++)
        {
            GameObject life = Instantiate(lifePrefab, transform);
            lives.Add(life);
        }

    }

    public void LoseLife()
    {
        numberoflives--;
        GameObject laslife = lives[lives.Count - 1];
        lives.Remove(laslife);
        Destroy(laslife);
        if(numberoflives <= 0)
        {
            Debug.Log("gameOver");
        }
    }
}
