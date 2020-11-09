using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class palmOrientation : MonoBehaviour
{

    float xPos, yPos, zPos;

    Transform Palm;
    Transform thumbFinger;
    Transform pinkyFinger;

    Vector3 thumbPos, pinkyPos;
    Vector3 initialPos = new Vector3(0f, 0f, 0f);

    float subtractionX = 0;
    float subtractionY = 0;
    float subtractionZ = 0;

    public bool printOrientations = false;

    float i = 0;

    void Start() {
                  
        // Thumb is Fingertip Transform 1
        // Pinky is Fingertip Transform 5  
        thumbFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 1");
        pinkyFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 5");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {

            thumbPos = thumbFinger.transform.position;
            pinkyPos = pinkyFinger.transform.position;
            
            subtractionX = thumbPos.x - pinkyPos.x;
            subtractionY = thumbPos.y - pinkyPos.y;
            subtractionZ = thumbPos.z - pinkyPos.z;

            // print(subtractionY);

            if (printOrientations)
            {
                if (thumbPos != initialPos)
                {
                    if (subtractionX < 0.4 && subtractionX > 0.2 && subtractionY >-0.07)
                    {
                        print("down");
                    }
                    else if (subtractionX > -0.4 && subtractionX < -0.2)
                    {
                        print("up");
                    }
                    else if (subtractionY > 0.1)
                    {
                        print("side");
                    }
                    else if (subtractionY < -0.07 && subtractionY > -0.12)
                    {
                        print("forward");
                    }
                }
            }


        }
        catch
        {}
    }
}
