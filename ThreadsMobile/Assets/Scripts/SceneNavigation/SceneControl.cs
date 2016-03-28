using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using TouchScript.Gestures;

public class SceneControl: MonoBehaviour {

    public Reporter rep;
    public GameObject ScoreWindow;
    public Text ScoreText;
    private Background back;
    private TapGesture tapBack;

    public void Start()
    {
        rep = FindObjectOfType<Reporter>();
        back = Background.Instance;
        tapBack = back.GetComponent<TapGesture>();
    }

    public void Restart()
    {
        if(rep != null && rep.show)
            return;

        ShipLinesManager.resetShips();
    }

    public void ExitApp()
    {
        if(rep != null && rep.show)
            return;

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER
        Application.OpenURL(webplayerQuitURL);
    #else
        Application.Quit();
    #endif
    }

	public void Submit()
	{
        if(rep != null && rep.show)
            return;

        int totalScore = 0;
		GameObject[] characters = GameObject.FindGameObjectsWithTag ("Character");

		for (int i = 0; i < characters.Length; i++) {
			CharacterCore character = characters [i].GetComponent<CharacterCore>();
			totalScore += character.ScoreRelationships ();
		}

        ScoreWindow.SetActive(true);
        ScoreText.text = totalScore.ToString();
	}
}
