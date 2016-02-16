using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneControl: MonoBehaviour {


    public Reporter rep;

    public void Start()
    {
        rep = FindObjectOfType<Reporter>();
    }

    public void Restart()
    {
        if(rep.show)
            return;
        //TODO: Maybe once we have a puzzle save file we can replace this with something smarter?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitApp()
    {
        if(rep.show)
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
        if(rep.show)
            return;

        int totalScore = 0;
		GameObject[] characters = GameObject.FindGameObjectsWithTag ("Character");

		for (int i = 0; i < characters.Length; i++) {
			CharacterCore character = characters [i].GetComponent<CharacterCore>();
			totalScore += character.ScoreRelationships ();
		}

		GameObject scoreText = GameObject.FindGameObjectWithTag ("Score Text");
		Text text = scoreText.GetComponent<Text> ();
		text.text = totalScore.ToString();
	}
}
