using UnityEngine;
using System.Collections;

public class Mane_Menu : MonoBehaviour {

	// Use this for initialization
	public int window=1;
	void Start()
	{
		window = 1;
	}


	void OnGUI () 
	{
		if (window == 1) 
		{
						GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
						if (GUI.Button (new Rect (10, 30, 180, 30), "Играть")) 
						{ 
								window = 2;   
						} 						
						if (GUI.Button (new Rect (10, 70, 180, 30), "Об игре"))								 
						{ 
								window = 3;   
						} 
						if (GUI.Button (new Rect (10, 110, 180, 30), "Выйти")) 
						{ 
								window = 4;   
						}
						GUI.EndGroup ();
		}
		if (window == 2) 
		{
			GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
			GUI.Label(new Rect(50, 10, 180, 30), "Выберите уровень");
			if(GUI.Button (new Rect (10,40,180,30), "Уровень 1")) 
			{ 
				Debug.Log("Уровень 1 загружен"); 
				Application.LoadLevel("Default"); 
			} 
			if(GUI.Button (new Rect (10,80,180,30), "Скоро")) 
			{ 
				Debug.Log("Error"); 				 
			} 
			if(GUI.Button (new Rect (10,160,180,30), "Назад")) 
			{ 
				window = 1; 
			}
			GUI.EndGroup();
		}
		if (window == 3) 
		{
			GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
			if(GUI.Button(new Rect(10, 30, 180, 30), "Об Игре"))
			{
				window=5;
			}
			if(GUI.Button (new Rect (10,90,180,30), "Назад")) 	
			{ 
				window = 1; 
			} 
			GUI.EndGroup();
		}
		if (window == 4) 
		{
			GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
			GUI.Label(new Rect(50, 10, 180, 30), "Вы точно хотите выйти?");
			if(GUI.Button (new Rect (10,40,180,30), "Да")) 
			{ 
				Application.Quit(); 
			} 
			if(GUI.Button (new Rect (10,80,180,30), "Нет")) 
			{ 
				window = 1; 
			} 
			GUI.EndGroup();
		}
		if (window == 5)
		{
			GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
			GUI.Label(new Rect(50, 10, 180, 30), "Об игре");
			if(GUI.Button (new Rect (10,90,180,30), "Назад")) 	
			{ 
				window = 1; 
			} 
			GUI.EndGroup();
		}
	}
}
