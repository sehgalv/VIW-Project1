using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAnimation : MonoBehaviour {

    public Animator anim;
    public Transform body;
    public Camera target;
    public AudioSource audio;
    public AudioSource main_audio;
    public AudioSource convo2;
    public AudioSource convo3;
    bool rotation = false;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //var n = target.transform.position - body.transform.position;
        Quaternion targetMeasurement = Quaternion.Euler(0, (target.transform.position.x) *30.0f, 0);
        print("x position of camera"+target.transform.position.x);
        print("picked up ");
        if (Time.time >= 60.0f && Time.time < 75.0f)//Random.Range(30.0f, 60.0f)
        {
            anim.Play("idle");
            audio.Stop();
            main_audio.Stop();
            convo2.Stop();
            convo3.Stop();
            if (Time.time >= 63.0f && (rotation == false))
            {



                //

                print("body rotated");
                if (Time.time >= 68.0f)
                {
                    rotation = true;
                    body.transform.Rotate(new Vector3(0, body.transform.rotation.y, 0));



                }

                /*else
                {
                    body.transform.LookAt(target.tr
                    ansform.position);
                }*/
                // body.transform.rotation = Quaternion.LookRotation(target.transform.up,-target.transform.forward);
                // body.transform.LookAt(target.transform); //, target.transform.up
                // body.transform.rotation = Quaternion.Euler(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
                // body.transform.rotation = Quaternion.LookRotation(n) * Quaternion.Euler(0, 90, 0);



                body.transform.rotation = Quaternion.Slerp(transform.rotation, targetMeasurement, Time.deltaTime * 2.0f);
                // print(body.GetInstanceID() + " "+body.position.x + " "+body.position.y +" " + body.position.z);
            }


        }
        else if (Time.time >= 75.0f && Time.time <90.0f)
        {
            anim.Play("clapping");
        }

        else if (Time.time >= 90.0f) {
            anim.Play("sitting");
        } else
        {
            anim.Play("handmotion");
        }
        
	}
}
