using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAnimation : MonoBehaviour {

    public Animator anim;
    public Transform body;
    public Camera target;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
       //var n = target.transform.position - body.transform.position;
        print("picked up ");
        if (Time.time >= 30.0f)//Random.Range(30.0f, 60.0f)
        {
            anim.Play("idle");
            if (Time.time >= 33.0f)
            {
                //body.transform.rotation = Quaternion.Euler(-Camera.main.transform.rotation.x, -Camera.main.transform.rotation.y, -Camera.main.transform.rotation.z);
                print("body rotated");
                // body.transform.rotation = Quaternion.LookRotation(target.transform.up,-target.transform.forward);
                 body.transform.LookAt(target.transform, target.transform.up);
              // body.transform.rotation = Quaternion.LookRotation(n) * Quaternion.Euler(0, 90, 0);
            }

        } else
        {
            anim.Play("handmotion");
        }
        
	}
}
