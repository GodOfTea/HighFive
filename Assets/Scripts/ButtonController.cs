using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

	public GameController gameController;
	public Text AvgTimer;

	void OnMouseDown ()
	{		
		gameController.next = true;
		gameObject.SetActive (false);
		gameController.RunWaitingTime = 0;
		AvgTimer.text = "";
	}
}
