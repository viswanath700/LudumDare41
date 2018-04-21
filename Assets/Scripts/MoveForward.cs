using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentValue = gameObject.transform.position;
		gameObject.transform.position = currentValue + new Vector3 (0, 0, Time.deltaTime);
	}
}
