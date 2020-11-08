using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


public class fingerPointing : MonoBehaviour
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

    float subtractionX = 0;
    float subtractionY = 0;


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

            // print(subtractionY);
            
            if (thumbPos != initialPos)
            {
                if (subtractionX < 0.4 && subtractionX > 0.2)
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
            }


        }
        catch
        {}
    }
}
