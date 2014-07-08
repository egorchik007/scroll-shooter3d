using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	int lastScore = 0;

	public GUIStyle labelStyle;
	public GUIStyle buttonStyle;

	void Start()
	{
		if (PlayerPrefs.HasKey("LastScore"))
		    lastScore = PlayerPrefs.GetInt("LastScore");
	}

	void OnGUI()
	{
		GUI.Label(new Rect(100, 0, Screen.width, Screen.height), "Score: " + lastScore, labelStyle);
		if (GUI.Button(new Rect(0,0,100,100), "START", buttonStyle))
			Application.LoadLevel("Default");
		if (GUI.Button(new Rect(0,100,100,100), "QUIT"))
			Application.Quit();
	}
}
