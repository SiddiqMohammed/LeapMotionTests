using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ball;
    public GameObject cube;
    public Transform spawnPoint;
    Vector3 myVector;
    

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
            myVector = new Vector3(Random.Range(spawnPoint.position.x + 1, spawnPoint.position.x - 1), spawnPoint.position.y, Random.Range(spawnPoint.position.z + 1, spawnPoint.position.z - 1));
            Instantiate(ball, myVector, spawnPoint.rotation);
        }
    }
    void spawnCube(int num)
    {
        for (int i = 0; i < num; i++)
        {
            myVector = new Vector3(Random.Range(spawnPoint.position.x + 1, spawnPoint.position.x - 1), spawnPoint.position.y, Random.Range(spawnPoint.position.z + 1, spawnPoint.position.z - 1));
            Instantiate(cube, myVector, Quaternion.identity);
        }
    }    
}
