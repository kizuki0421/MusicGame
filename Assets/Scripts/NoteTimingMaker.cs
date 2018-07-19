using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTimingMaker : MonoBehaviour {
	
	private AudioSource _audioSource;

	public GameObject startButton;

	private CSVWriter _CSVWriter;

	private bool _isPlaying = false;

	private float _startTime = 0;

	private int t = 2;

	void Start () {
		_audioSource = GameObject.Find ("GameMusic").GetComponent<AudioSource> ();
		_CSVWriter = GameObject.Find ("CSVWriter").GetComponent<CSVWriter>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_isPlaying) {
			DetectKey ();
		}
	}

	public void StartMusic(){
		startButton.SetActive (false);
		_audioSource.Play ();
		_startTime = Time.time;
		_isPlaying = true;
	}

	void DetectKey(){
		t += 1;
		if (Input.GetKey (KeyCode.F)) {
			if (t % 3 == 0) {
				WriteNoteTiming (0);
				t = 0;
			}
		}
		if (Input.GetKey (KeyCode.J)) {
			if (t % 3 == 0) {
				WriteNoteTiming (4);
				t = 0;
			}
		} 
	}

	void WriteNoteTiming(int num){
		Debug.Log (GetTiming ());
		_CSVWriter.WriterCSV (GetTiming ().ToString () + "," + num.ToString ());
	}

	float GetTiming(){
		return Time.time - _startTime;
	}
}
