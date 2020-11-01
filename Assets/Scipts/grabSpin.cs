using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// [System.Serializable]
// public struct Gesture
// {
//     public string name;
//     public Vector3[] fingerPositions;
// }


public class grabSpin : MonoBehaviour
{

     public string currentGestureName;

    public float tolerance;
    public Vector3[] leftHandPos = new Vector3[15];
    public Vector3[] rightHandPos = new Vector3[15];
    public bool saveActive = true;

    public List<Gesture> gestureList;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    float xPos, yPos, zPos;

    Transform Palm;
    Transform IndexFinger;
    Transform MiddleFinger;


    // Update is called once per frame
    void Update()
    {
        try
        {
            if (gameObject.name == "cubeLeft")
            {
                Palm = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");
                IndexFinger = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");

            } 
            else
            {
                Palm = GameObject.Find("InteractionHand_R").transform.Find("Palm Transform");
            }
            print("POS " + Palm.transform.position);            
            // print("POS " + Palm.transform.position.x);            
            // xPos = Palm.transform.position.x;
            // yPos = Palm.transform.position.y;
            // zPos = Palm.transform.position.z;



        }
        catch
        {}
    }
}
