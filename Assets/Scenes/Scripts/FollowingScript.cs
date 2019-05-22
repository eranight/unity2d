using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour {

    public GameObject leader;
    //private Vector3 offset;

	// Use this for initialization
	void Start () {
        //offset = transform.position - leader.transform.position;
        transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y, transform.position.z);
        //transform.position = leader.transform.position + offset;
	}
}
