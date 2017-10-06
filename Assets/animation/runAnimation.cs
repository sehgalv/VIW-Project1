using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAnimation : MonoBehaviour {

    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        print("picked up ");
        anim.Play("handlanguage");
        //if (Time.time >= Random.Range(30.0f, 60.0f))
        //{
        //    anim.StopPlayback();
        //}
        //} else
        //{
        //    anim.Play("handlanguage");
        //}
        
	}
}
