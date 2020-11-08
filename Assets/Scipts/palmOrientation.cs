using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class palmOrientation : MonoBehaviour
{

    public float tolerance;
    public List<Gesture> gestureList;

    float xPos, yPos, zPos;

    Transform Palm;
    Transform thumbFinger;
    Transform pinkyFinger;

    Vector3 thumbPos, pinkyPos;
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
        // targetObj = GameObject.Find("grabSpin");
        // targetObj2 = GameObject.Find("car 1203 blue");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            // Thumb is Fingertip Transform 1
            // Pinky is Fingertip Transform 5
            
            thumbFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 1");
            pinkyFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 5");

            thumbPos = thumbFinger.transform.position;
            pinkyPos = pinkyFinger.transform.position;
            
            subtraction = thumbPos.x - pinkyPos.x;

            if (subtraction < 0)
            {
                print("Up");
            }
            else
            {
                print("Down");
            }


        }
        catch
        {}
    }
}
