using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Kinect;

public class motionController : MonoBehaviour {

    //we are going to create a custome gesture using the kinect ! 
    //the GETJOINTPOSITIONDEMO.cs was a real help 



    // Use this for initialization
  
    private KinectInterop.JointType head = KinectInterop.JointType.SpineShoulder; 
    private KinectInterop.JointType hip = KinectInterop.JointType.SpineBase;
    private KinectInterop.JointType leftKnee = KinectInterop.JointType.KneeLeft;
    private KinectInterop.JointType rightKnee = KinectInterop.JointType.KneeRight;
    private KinectInterop.JointType leftShoulder = KinectInterop.JointType.ShoulderLeft;
    private KinectInterop.JointType rightShoulder = KinectInterop.JointType.ShoulderRight;
    public Vector3 headJointPosition;
    public Vector3 hipJointPosition;
    public Vector3 leftKneeJointPosition;
    public Vector3 rightKneeJointPosition;
    public Vector3 leftShoulderJointPosition;
    public Vector3 rightShoulderJointPosition;
    private long trackedUsersId;
    public float moveSpeed = 2.5f;
    public float turnSpeed = 12.5f;


	void Start () {
        
		
	}

    void checkPosture() {
        KinectManager manager = KinectManager.Instance;
        trackedUsersId = manager.GetPrimaryUserID();
        if (manager.IsUserDetected() && manager.IsUserTracked(trackedUsersId))
        {
            print("user detected");
            if (manager.IsJointTracked(trackedUsersId, (int)head) && manager.IsJointTracked(trackedUsersId, (int)hip) && manager.IsJointTracked(trackedUsersId, (int)leftKnee) && manager.IsJointTracked(trackedUsersId, (int)rightKnee) && manager.IsJointTracked(trackedUsersId, (int)rightShoulder) && manager.IsJointTracked(trackedUsersId, (int)leftShoulder))
            {
                print("got the joints .. of the body");
                headJointPosition = manager.GetJointPosition(trackedUsersId, (int)head);
                hipJointPosition = manager.GetJointPosition(trackedUsersId, (int)hip);
                leftKneeJointPosition = manager.GetJointPosition(trackedUsersId, (int)leftKnee);
                rightKneeJointPosition = manager.GetJointPosition(trackedUsersId, (int)rightKnee);
                leftShoulderJointPosition = manager.GetJointPosition(trackedUsersId, (int)leftShoulder);
                rightShoulderJointPosition = manager.GetJointPosition(trackedUsersId, (int)rightShoulder);


                if ((headJointPosition.z - hipJointPosition.z) < -0.05 )
                {
                    gameObject.transform.Translate(0, 0, (moveSpeed * Time.deltaTime));
                    print("lean forward"+ (headJointPosition.y - hipJointPosition.y));
                    print("going forward");
            
                }
                else if(leftKneeJointPosition.y > 0.65 || rightKneeJointPosition.y > 0.65)
                {
                    gameObject.transform.Translate(0, 0, (moveSpeed * 4 * Time.deltaTime));
                    print("left knee" + leftKneeJointPosition.y);
                    print("right knee" + rightKneeJointPosition.y);
                    print("going forward");
                }
                else
                {
                    gameObject.transform.Translate(0, 0, 0);
                    print(headJointPosition.y - hipJointPosition.y);

                    print("not moving");
                }

                //rotation
                if ((leftShoulderJointPosition.z - rightShoulderJointPosition.z) > 0.05)
                {
                    gameObject.transform.Rotate(Vector3.up, (-turnSpeed * Time.deltaTime));
                    print(leftShoulderJointPosition.z - rightShoulderJointPosition.z);
                    print("rotating left");
                }
                else if ((leftShoulderJointPosition.z - rightShoulderJointPosition.z) < -0.05)
                {
                    gameObject.transform.Rotate(Vector3.up, (turnSpeed * Time.deltaTime));
                    print(leftShoulderJointPosition.z - rightShoulderJointPosition.z);
                    print("rotating right");
                }



            }//if the joint is tracked ny this user.. 

        }//if the kinect senses atleast a user and if the user is the primary user id, or the first sensed user
    }

	
	// Update is called once per frame
	void Update () {
        checkPosture();
       

    }
}
