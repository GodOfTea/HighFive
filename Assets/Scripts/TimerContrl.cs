using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerContrl : MonoBehaviour {

	public GameObject canvas;
	public GameObject timer_pref;
	public GameObject AvgTimer;

	private int _total;
	private int timerCount;
	private int YtimerPos;
	private float _avgTime;
	private float _thisRunTime;
	private float sumTime;

	static private string _thisRunText;

	private GameObject[] _timers = new GameObject[5];

	void Start () 
	{
		sumTime = 0;
		_total = 1;
		_avgTime = 0;
		Reset ();
	}

	void Update () 
	{
		//
	}

	public void Spawn() //костыль
	{	
		_thisRunTime = GetComponent<GameController> ().ThisRunTime;
		_thisRunText = _thisRunTime.ToString ("0.0000");
		if (timerCount < 5) {
			if (_timers [timerCount] != null)
				Destroy (_timers [timerCount]);
			_timers[timerCount] = Instantiate (timer_pref, timer_pref.transform.position = new Vector3 (150, YtimerPos, 10), Quaternion.identity) as GameObject;
			_timers[timerCount].transform.SetParent (canvas.transform, false);
			_timers[timerCount].GetComponent<Text> ().text = _thisRunText;
			AverageTimer ();
			YtimerPos -= 100;
			timerCount++;
			_total++;
		} else {
			Reset (); 
			Spawn ();
		}
			
	}

	void Reset ()
	{
		timerCount = 0;
		YtimerPos = 1300;
	}

	void AverageTimer ()
	{
		sumTime += _thisRunTime;
		_avgTime = sumTime / _total;
		AvgTimer.GetComponent<Text> ().text = "Ср. время: " + _avgTime.ToString("0.0000");
	}

	public void MissClick ()
	{
		AvgTimer.GetComponent<Text> ().text = "Not time yet";
	}
}