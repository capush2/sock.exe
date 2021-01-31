using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
	public Button home;

	void Start()
	{
		home.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
	}
}
