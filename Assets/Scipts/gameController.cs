using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject ball;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnBall();
        }
        
    }

    void spawnBall()
    {
        Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }
}
