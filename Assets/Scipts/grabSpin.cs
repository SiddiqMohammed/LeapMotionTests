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

    Transform Palm;
    Transform IndexFinger;

    Vector3 palmPos, IndexPos;
    Vector3 initialPos = new Vector3(0f, 0f, 0f);

    float tiltAroundZ;
    public float tiltAngle = 360.0f;
    float smooth = 5.0f;

    GameObject targetObj;
    GameObject targetObj2;

    double distanceBW;

    void Start() {
        targetObj = GameObject.Find("grabSpin");
        targetObj2 = GameObject.Find("car 1203 blue");

        // IndexFinger is Fingertip Transform 2
        // MiddleFinger is Fingertip Transform 3
        Palm = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");
        IndexFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 2");
    }

    void Update()
    {
        try
        {
            palmPos = Palm.transform.position;
            IndexPos = IndexFinger.transform.position;

            if (palmPos != initialPos)
            {
                // Finding dist b/w Index finger and palm using 3D coordinate geometry
                distanceBW = Math.Sqrt(Math.Pow((palmPos.x - IndexPos.x), 2) + Math.Pow((palmPos.y - IndexPos.y), 2) + Math.Pow((palmPos.z - IndexPos.z), 2));
                
                if (distanceBW < 0.08 && distanceBW > 0.06)
                {
                    print("fist");

                    tiltAroundZ = palmPos.x * tiltAngle;

                    Quaternion target = Quaternion.Euler(0, -tiltAroundZ, 0);

                    // Dampen towards the target rotation
                    targetObj.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
                    targetObj2.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
                }
            }


        }
        catch
        {}
    }
}
