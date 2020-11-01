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


public class Spinner : MonoBehaviour
{
  
    public string currentGestureName;

    public float tolerance;
    public Vector3[] leftHandPos = new Vector3[15];
    public Vector3[] rightHandPos = new Vector3[15];
    public bool saveActive = true;

    public List<Gesture> gestureList;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            var testPlane = GameObject.Find("Palm Transform");
            print("POS " + testPlane.transform.position);            
        }
        catch
        {}
        
    }
}
