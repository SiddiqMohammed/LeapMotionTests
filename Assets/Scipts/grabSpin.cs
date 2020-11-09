using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using System; 

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

    float subtractionX = 0;
    float subtractionY = 0;

    float tiltAngle = 360.0f;
    float smooth = 5.0f;

    GameObject targetObj;
    GameObject targetObj2;

    float i = 0;

    double distanceBW;

    void Start() {
        targetObj = GameObject.Find("grabSpin");
        targetObj2 = GameObject.Find("car 1203 blue");

        // IndexFinger is Fingertip Transform 2
        // MiddleFinger is Fingertip Transform 3
        
        Palm = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");
        IndexFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 2");
        MiddleFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 3");
    }
    // Update is called once per frame
    void Update()
    {
        try
        {
            palmPos = Palm.transform.position;
            IndexPos = IndexFinger.transform.position;
            MiddlePos = MiddleFinger.transform.position;
            

            subtractionX = palmPos.x - IndexPos.x;
            subtractionY = palmPos.y - IndexPos.y;

            distanceBW = Math.Sqrt(Math.Pow((palmPos.x - IndexPos.x), 2) + Math.Pow((palmPos.y - IndexPos.y), 2) + Math.Pow((palmPos.z - IndexPos.z), 2));
            // print("distanceBW " + distanceBW);

            if (palmPos != initialPos)
            {
                if (distanceBW < 0.08 && distanceBW > 0.06)
                {
                    print("fist");
                }
            }

            // print(subtractionY);
            
            // if (palmPos != initialPos)
            // {
            //     // Check if hand is in fist position facing down
            //     if (subtractionX > -0.06 && subtractionX < 0.06)
            //     {
            //         print("fist");

            //         float tiltAroundZ = palmPos.x * tiltAngle;

            //         Quaternion target = Quaternion.Euler(0, -tiltAroundZ, 0);

            //         // Dampen towards the target rotation
            //         targetObj.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
            //         targetObj2.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
            //     }
            //     // else if (subtractionY > -0.03 && subtractionY < -0.02)
            //     // {
            //     //     print("fist side");
            //     // }
            // }

        }
        catch
        {}
    }
}
