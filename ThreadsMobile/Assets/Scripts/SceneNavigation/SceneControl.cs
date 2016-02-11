using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class SceneControl: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Restart()
    {
        //TODO: Maybe once we have a puzzle save file we can replace this with something smarter?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitApp()
    {
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
