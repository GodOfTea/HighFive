using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class GameController : MonoBehaviour {

	private Image img;

	public float ThisRunTime = 0;
	public float WaitingTime = 0;
	public float RunWaitingTime;
	public bool next;
	public bool timerOn;

	public GameObject AvgTimer;
	public GameObject Button;

	void Start () 
	{
		img = GetComponent<Image> ();
		img.color =  new Color (96/255f, 97f/255f, 200f/255f);
		next = true;
		timerOn = false;
	}

	void OnMouseDown () //исправить костыль
	{
		if (!timerOn) {
			GetComponent <TimerContrl>().MissClick ();
			Reset ();
		}
		else 
		{
			GetComponent<TimerContrl>().Spawn ();
			Reset ();
		}
	}

	void Update ()
	{
		if (next) 
			NewTry ();
		if (WaitingTime > 0)
			Waiting ();
		if (timerOn) {
			ThisRunTime += Time.deltaTime;
		}
		
	}

	void Reset ()
	{
		img.color =  new Color (96/255f, 97f/255f, 200f/255f);
		Button.SetActive(true);
		timerOn = false;
		ThisRunTime = 0;
	}

	void Waiting ()
	{
		if (RunWaitingTime <= WaitingTime) {
			RunWaitingTime += Time.deltaTime;
		} else {
			WaitingTime = 0;
			timerOn = true;
			img.color = new Color (204 / 255f, 41 / 255f, 51 / 255f);
		}
	}

	void NewTry()
	{
		WaitingTime = Random.Range (0.5f, 5f);
		next = false;
	}
		
}