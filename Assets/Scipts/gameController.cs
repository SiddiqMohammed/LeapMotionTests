using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class gameController : MonoBehaviour
{
    public GameObject ball;
    public GameObject cube;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // spawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnBall();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            spawnCube();
        }
        
    }

    void spawnBall()
    {
        Instantiate(ball, spawnPoint.position, Quaternion.identity);
    }

    void spawnCube()
    {
        Instantiate(cube, spawnPoint.position, Quaternion.identity);
    }
}
