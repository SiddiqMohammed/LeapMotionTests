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

    public float tolerance;
    public List<Gesture> gestureList;

    float xPos, yPos, zPos;

    Transform Palm;
    Transform IndexFinger;
    Transform MiddleFinger;

    Vector3 palmPos, IndexPos, MiddlePos;
    Vector3 PreviousLeastPosition = new Vector3(100000f, 10000f, 10000f);
    Vector3 initialPos = new Vector3(0f, 0f, 0f);

    double FistValue = 0.08039556;

    bool setCallibrator = false;

    float subtraction = 0;

    float tiltAngle = 360.0f;
    float smooth = 5.0f;

    GameObject targetObj;
    GameObject targetObj2;

    float i = 0;

    void Start() {
        targetObj = GameObject.Find("grabSpin");
        targetObj2 = GameObject.Find("car 1203 blue");
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            // IndexFinger is Fingertip Transform 2
            // MiddleFinger is Fingertip Transform 3
            
            Palm = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");
            IndexFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 2");
            MiddleFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 3");

            palmPos = Palm.transform.position;
            IndexPos = IndexFinger.transform.position;
            MiddlePos = MiddleFinger.transform.position;
            

            // calibrate fist
            if (Input.GetKeyDown(KeyCode.A))
            {
                subtraction = palmPos.x - IndexPos.x;

                // if (palmPos.x - IndexPos.x < PreviousLeastPosition.x)
                // {
                //     PreviousLeastPosition.x = IndexPos.x;
                // }
                // print(subtraction);

            }

            subtraction = palmPos.x - IndexPos.x;
            
            // Check if hand is in fist position
            if (subtraction > -0.05 && palmPos != initialPos)
            {
                print("fist");

                float tiltAroundZ = palmPos.x * tiltAngle;

                Quaternion target = Quaternion.Euler(0, -tiltAroundZ, 0);

                // Dampen towards the target rotation
                targetObj.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
                targetObj2.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
            } 

            // Thumb is Fingertip Transform 1
            // Pinky is Fingertip Transform 5

        }
        catch
        {}
    }
}
