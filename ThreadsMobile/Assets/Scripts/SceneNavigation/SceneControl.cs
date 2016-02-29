using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneControl: MonoBehaviour {

    public Reporter rep;
    public GameObject ScoreWindow;
    public Text ScoreText;

    public void Start()
    {
        rep = FindObjectOfType<Reporter>();
    }

    public void Restart()
    {
        if(rep != null && rep.show)
            return;
        //TODO: Maybe once we have a puzzle save file we can replace this with something smarter?
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
