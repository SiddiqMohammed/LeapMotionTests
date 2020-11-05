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

    double FistValue = 0.08039556;

    bool setCallibrator = false;

    float subtraction = 0;

    float tiltAngle = 60.0f;
    float smooth = 5.0f;

    GameObject targetObj;


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

            // PalmR = GameObject.Find("InteractionHand_R").transform.Find("Palm Transform");
            // IndexFingerR = GameObject.Find("InteractionHand_R").transform.Find("Fingertip Transform 2");
            // MiddleFingerR = GameObject.Find("InteractionHand_R").transform.Find("Fingertip Transform 3");


            palmPos = Palm.transform.position;
            IndexPos = IndexFinger.transform.position;
            MiddlePos = MiddleFinger.transform.position;
            
            // print(palmPos.x);
            // print(IndexPos.x);

            // calibrate fist
            if (Input.GetKeyDown(KeyCode.A))
            {
                setCallibrator = true;
                // print("palmPos" + palmPos);
                // print("IndexPos" + IndexPos);

            }

            if (setCallibrator)
            {
        
                subtraction = palmPos.x - IndexPos.x;

                // if (palmPos.x - IndexPos.x < PreviousLeastPosition.x)
                // {
                //     PreviousLeastPosition.x = IndexPos.x;
                // }
                print(subtraction);
                setCallibrator = false;
            }

            subtraction = palmPos.x - IndexPos.x;
            
            // Check if hand is in fist position
            if (subtraction > -0.05)
            {
                print("fist");

                targetObj = GameObject.Find("grabSpin");

                float tiltAroundZ = palmPos.x * tiltAngle;

                Quaternion target = Quaternion.Euler(0, -tiltAroundZ, 0);

                // Dampen towards the target rotation
                targetObj.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        
            }




            // if (palmPos.x - IndexPos.x == (FistValue + 0.1) || palmPos.x - IndexPos.x == (FistValue - 0.1))
            // {
            //     print("fist");
            // }
            // else
            // {
            //     print("open");
            // }


            // print("POS " + Palm.transform.position);            
            // print(PreviousLeastPosition.x);            


        }
        catch
        {}
    }
}
