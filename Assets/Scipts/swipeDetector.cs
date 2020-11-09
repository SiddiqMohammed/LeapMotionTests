using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using System; 

public class swipeDetector : MonoBehaviour
{
    public List<float> positionListX = new List<float>();
    public List<float> positionListY = new List<float>();

    Transform Palm;
    Transform thumbFinger;
    Transform pinkyFinger;

    Vector3 palmPos, IndexPos;
    Vector3 thumbPos, pinkyPos;

    Vector3 initialPos = new Vector3(0f, 0f, 0f);
    
    float subtractionX = 0;
    float subtractionY = 0;

    public float timeBetweenDetectionsX = 0.25f;
    public float timeBetweenDetectionsY = 0.25f;

    double difference = 0.15;

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
            
            subtractionX = thumbPos.x - pinkyPos.x;
            subtractionY = thumbPos.y - pinkyPos.y;


            if (thumbPos != initialPos)
            {
                // Check if the hand is sideways
                // if (subtractionY < -0.07 && subtractionY > -0.12)
                if (subtractionY > 0.1)
                {

                    if (timeBetweenDetectionsX > 0)
                    {
                        timeBetweenDetectionsX -= Time.deltaTime;

                        if (timeBetweenDetectionsX <= 0)
                        {
                            positionListX.Add(palmPos.x);
                            // print(positionListX.Count);

                            timeBetweenDetectionsX = 0.25f;

                            if (positionListX.Count > 1)
                            {
                                if (positionListX[1] - positionListX[0] > difference)
                                {
                                    print("SwipeRight");

                                    var cylinderRenderer = this.GetComponent<Renderer>();
                                    cylinderRenderer.material.SetColor("_Color", Color.red);
                                }

                                else if (positionListX[0] - positionListX[1] > difference)
                                {
                                    print("SwipeLeft");

                                    var cylinderRenderer = this.GetComponent<Renderer>();
                                    cylinderRenderer.material.SetColor("_Color", Color.blue);
                                }
                                positionListX.Clear();
                            }
                        }
                    }

                }
                // Hand facing up
                else if (subtractionX > -0.4 && subtractionX < -0.2)
                {
                    if (timeBetweenDetectionsY > 0)
                    {
                        timeBetweenDetectionsY -= Time.deltaTime;

                        if (timeBetweenDetectionsY <= 0)
                        {
                            positionListY.Add(palmPos.y);
                            // print(positionListX.Count);

                            timeBetweenDetectionsY = 0.25f;
                            if (positionListY.Count > 1)
                            {
                                if (positionListY[1] - positionListY[0] > difference)
                                {
                                    print("SwipeUp");

                                    // var cylinderRenderer = this.GetComponent<Renderer>();
                                    // cylinderRenderer.material.SetColor("_Color", Color.red);
                                }

                                // else if (positionListY[0] - positionListY[1] > difference)
                                // {
                                //     print("SwipeDown");

                                //     // var cylinderRenderer = this.GetComponent<Renderer>();
                                //     // cylinderRenderer.material.SetColor("_Color", Color.blue);
                                // }
                                positionListY.Clear();
                            }
                        }
                    }
                }
                // Hand facing down
                else if (subtractionX < 0.4 && subtractionX > 0.2 && subtractionY >-0.07)
                {
                    if (timeBetweenDetectionsY > 0)
                    {
                        timeBetweenDetectionsY -= Time.deltaTime;

                        if (timeBetweenDetectionsY <= 0)
                        {
                            positionListY.Add(palmPos.y);
                            // print(positionListX.Count);

                            timeBetweenDetectionsY = 0.25f;
                            if (positionListY.Count > 1)
                            {
                                // if (positionListY[1] - positionListY[0] > difference)
                                // {
                                //     print("SwipeUp");

                                //     // var cylinderRenderer = this.GetComponent<Renderer>();
                                //     // cylinderRenderer.material.SetColor("_Color", Color.red);
                                // }

                                if (positionListY[0] - positionListY[1] > difference)
                                {
                                    print("SwipeDown");

                                    // var cylinderRenderer = this.GetComponent<Renderer>();
                                    // cylinderRenderer.material.SetColor("_Color", Color.blue);
                                }
                                positionListY.Clear();
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