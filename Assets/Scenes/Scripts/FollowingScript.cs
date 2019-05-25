using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingScript : MonoBehaviour {

    public GameObject leader;

	void Start () {
        transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y, transform.position.z);
	}
	
    void LateUpdate()
    {
        transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y, transform.position.z);
	}
}
