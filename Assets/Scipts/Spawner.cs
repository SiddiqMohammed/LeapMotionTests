using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject cube;
    public Transform spawnPoint;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnBall(1);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            spawnCube(1);
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            spawnCube(5);
            spawnBall(10);
        }
    }

    void spawnBall(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(ball, spawnPoint.position, spawnPoint.rotation);
        }
    }
    void spawnCube(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(cube, spawnPoint.position, Quaternion.identity);
        }
    }    
}
