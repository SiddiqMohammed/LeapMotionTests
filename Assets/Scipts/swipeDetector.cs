using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using System; 

public class swipeDetector : MonoBehaviour
{
    public List<float> positionList = new List<float>();

    Transform Palm;
    Transform thumbFinger;
    Transform pinkyFinger;

    Vector3 palmPos, IndexPos;
    Vector3 thumbPos, pinkyPos;

    Vector3 initialPos = new Vector3(0f, 0f, 0f);
    
    float subtractionY = 0;

    public float timeBetweenDetections = 0.25f;

    void Start() {

        // IndexFinger is Fingertip Transform 2
        // MiddleFinger is Fingertip Transform 3
        // IndexFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 2");
    }

    void Update()
    {
        try
        {
            Palm = GameObject.Find("InteractionHand_L").transform.Find("Palm Transform");
            palmPos = Palm.transform.position;

            thumbFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 1");
            pinkyFinger = GameObject.Find("InteractionHand_L").transform.Find("Fingertip Transform 5");

            thumbPos = thumbFinger.transform.position;
            pinkyPos = pinkyFinger.transform.position;
            
            subtractionY = thumbPos.y - pinkyPos.y;


            if (thumbPos != initialPos)
            {
                // Check if the hand is sideways
                if (subtractionY > 0.1)
                {

                    if (timeBetweenDetections > 0)
                    {
                        timeBetweenDetections -= Time.deltaTime;

                        if (timeBetweenDetections <= 0)
                        {
                            positionList.Add(palmPos.x);
                            // print(positionList.Count);

                            timeBetweenDetections = 0.25f;

                            if (positionList.Count > 1)
                            {
                                if (positionList[1] - positionList[0] > 0.1)
                                {
                                    print("rightSwipe");

                                    var cylinderRenderer = this.GetComponent<Renderer>();
                                    cylinderRenderer.material.SetColor("_Color", Color.red);
                                }

                                else if (positionList[0] - positionList[1] > 0.1)
                                {
                                    print("leftSwipe");
                                    var cylinderRenderer = this.GetComponent<Renderer>();
                                    cylinderRenderer.material.SetColor("_Color", Color.blue);
                                }
                                positionList.Clear();

                            }
                        }
                    }

                }
            }

        }
        catch
        {}
    }
}