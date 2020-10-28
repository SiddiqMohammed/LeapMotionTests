// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Leap;

// public class GestureHands : MonoBehaviour
// {
//     Controller controller;

//     // Start is called before the first frame update
//     void Start()
//     {
//         controller = new Controller();
//         controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
//         controller.Config.SetFloat("Gesture.Swipe.MinLength", 200.0f);
//         controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750f);
//         controller.Congig.Save();
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Frame frame = controller.Frame ();
//         GestureList gestures = frame.Gestures();

//         for (int i = 0; i < gestures.Count; i++)
//         {
//             Gesture gesture = gestures[i];

//             if(gesture.Type == Gesture.GestureType.TYPESWIPE)
//             {
//                 SwipeGesture Swipe = new SwipeGesture(gesture);
//                 Vector swipeDirection = Swipe.Direction;
//                 if(swipeDirection.x < 0)
//                 {
//                     print("LEFT");
//                 }
//                 else if (swipeDirection.x > 0)
//                 {
//                     print("RIGHT");
//                 }
//             }
//         }
//     }
// }
