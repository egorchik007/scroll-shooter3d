using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    private static GameController instance = null;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
                instance = Object.FindObjectOfType<GameController>();

            return instance;
        }
    }

    public int Score = 0;
    public GUIStyle ScoreLabelStyle;
    public int level = 1;

    public void Update()
    {
        //Debug.Log(Score);
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Score: " + Score, ScoreLabelStyle);
    }
}
