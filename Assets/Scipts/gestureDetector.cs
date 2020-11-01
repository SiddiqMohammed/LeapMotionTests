using Leap;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public struct Gesture
{
    public string name;
    public Vector3[] fingerPositions;
}

public class gestureDetector : MonoBehaviour
{
    public string currentGestureName;

    public float tolerance;
    public Vector3[] leftHandPos = new Vector3[15];
    public Vector3[] rightHandPos = new Vector3[15];
    public bool saveActive = false;

    public List<Gesture> gestureList;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && saveActive)
        {
            // SaveL();
            SaveR();
            print("saved");
        }

        //left hand
        // try
        // {
        //     var leftHand = GameObject.Find("Interaction Hand (Left)");
        //     LeftHandPos(leftHand);
        //     SetCurrentGesture(leftHand);
        //     DrawGestureName();
        // }
        // catch
        // {}

        try
        {
            var rightHand = GameObject.Find("Interaction Hand (Right)");
            RightHandPos(rightHand);
            SetCurrentGesture(rightHand);
            DrawGestureName();
        }
        catch
        {}


    }

    void DrawGestureName()
    {
        // TextMeshPro leftHand = GameObject.Find("LeftGestureName").GetComponent<TextMeshPro>();
        // leftHand.text = currentGestureName;
        
        TextMeshPro rightHand = GameObject.Find("RightGestureName").GetComponent<TextMeshPro>();
        rightHand.text = currentGestureName;
    }

    void SetCurrentGesture(GameObject rightHand)
    {
        foreach (Gesture gesture in gestureList)
        {
            bool tooFar = false;
            float totalDiff = 0;

            for (int i = 0; i < 15; i++)
            {
                Vector3 thisBone = rightHand.transform.InverseTransformPoint(rightHandPos[i]);
                float difference = Vector3.Distance(thisBone, gesture.fingerPositions[i]);

                if (difference > tolerance)
                {
                    tooFar = true;
                    break;
                }

                totalDiff += difference;
            }

            if (!tooFar && totalDiff < tolerance)
            {
                currentGestureName = gesture.name;
            }
            else
            {
                currentGestureName = "Not Sure";
            }
        }
    }

    void LeftHandPos(GameObject leftHand)
    {
        int counter = 0;
        for (int i = 0; i < 5; i++)
        {
            Transform finger = leftHand.transform.GetChild(i);

            for (int j = 0; j < 3; j++)
            {
                leftHandPos[counter] = finger.GetChild(j).transform.position;
                counter++;
            }
        }
    }
    void RightHandPos(GameObject rightHand)
    {
        int counter = 0;
        for (int i = 0; i < 5; i++)
        {
            Transform finger = rightHand.transform.GetChild(i);

            for (int j = 0; j < 3; j++)
            {
                rightHandPos[counter] = finger.GetChild(j).transform.position;
                counter++;
            }
        }
    }

    void SaveL()
    {
        var tempGesture = new Gesture();
        tempGesture.name = "Custom Gesture " + (gestureList.Count - 1);

       
        try
        {
            var leftHand = GameObject.Find("Interaction Hand (Left)");
            Vector3[] tempPos = new Vector3[15];
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                Transform finger = leftHand.transform.GetChild(i);

                for (int j = 0; j < 3; j++)
                {
                    tempPos[counter] = finger.GetChild(j).transform.position;
                    counter++;
                }
            }

            tempGesture.fingerPositions = tempPos;

            gestureList.Add(tempGesture);
        }
        catch (System.Exception)
        {

        }
       
    }
    
    void SaveR()
    {
        var tempGesture = new Gesture();
        tempGesture.name = "Custom Gesture " + (gestureList.Count - 1);

       
        try
        {
            var rightHand = GameObject.Find("Interaction Hand (Right)");
            Vector3[] tempPos = new Vector3[15];
            int counter = 0;

            for (int i = 0; i < 5; i++)
            {
                Transform finger = rightHand.transform.GetChild(i);

                for (int j = 0; j < 3; j++)
                {
                    tempPos[counter] = finger.GetChild(j).transform.position;
                    counter++;
                }
            }

            tempGesture.fingerPositions = tempPos;

            gestureList.Add(tempGesture);
        }
        catch (System.Exception)
        {

        }
       
    }
}
