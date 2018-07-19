using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeclere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		MeshRenderer _mesh = GetComponent<MeshRenderer> ();

		_mesh.material.color = new Color (0,0,0,1.0f);
	}
}
