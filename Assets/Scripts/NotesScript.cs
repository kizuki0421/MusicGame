using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesScript : MonoBehaviour {

	public int lineNum;
	private GameManager _gameManager;
	//notes生成、判定

	int tCount = 2;
	//long_notes用

	public float speed;
	public float radius;
	public float deg;
	private float rad_pos;
	Vector3	pos;



	float x,y,z=0.0f;

	void Start () {
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		deg = deg + (Time.deltaTime * speed);
		rad_pos = deg * Mathf.Deg2Rad;

		x = radius * Mathf.Cos (rad_pos);
		y = radius * Mathf.Sin (rad_pos);
		if (lineNum == 4) {
			this.transform.position = new Vector3 (x , y, z);
		} else {
			this.transform.position = new Vector3 (x * (-1), y, z);
		}
		if (this.transform.position.y < -5.0f) {
			Debug.Log ("false");
			Destroy (this.gameObject);
		}


	}
	void OnTriggerStay(Collider other){
		switch (lineNum) {
		case 0:
			CheckInput (KeyCode.J);
			break;
		case 4:
			CheckInput (KeyCode.F);
			break;
		default:
			break;
		}
	}

	void CheckInput(KeyCode key){
		tCount++;
		if (Input.GetKey (key)) {
			if(tCount%3==0){
			_gameManager.GoodTimingFunc (lineNum);
			Destroy (this.gameObject);
			}
		}
	}
}
