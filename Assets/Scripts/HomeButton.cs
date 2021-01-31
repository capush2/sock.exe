using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
	public Button home;
	private bool first = true;
	public GameObject[] toDisableOnHome;

	void Start()
	{
		home.GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		transform.parent.GetComponent<TabletSpritesContainer>().ChangeSprite(1);
		foreach(var i in toDisableOnHome)
        {
			i.SetActive(false);
        }
        if (first)
        {
			first = false;
			GameObject.Find("WelcomeMessage").SetActive(false);
        }
	}
}
