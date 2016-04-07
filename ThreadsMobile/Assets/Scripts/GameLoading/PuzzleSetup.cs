using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PuzzleSetup : MonoBehaviour {

	public List<CharacterCore> characters;

	// Use this for initialization
	void Start () {
		if (GameManager.Instance.getPuzzleType () == "Random") {
			foreach (CharacterCore character in this.characters) {
				character.RandomSetup ();
			}
		} else if (GameManager.Instance.getPuzzleType () == "Campaign") {
			PuzzleData puzzle = PuzzleManager.LoadPuzzle (GameManager.Instance.getPuzzleName ());
			int numCharacters = puzzle.Characters.Count;
			if (numCharacters == 2) {
				characters [0].gameObject.SetActive (false);
				characters [2].gameObject.SetActive (false);
				characters [3].gameObject.SetActive (false);

				characters [1].PuzzleSetup (puzzle.Characters [0]);
				characters [4].PuzzleSetup (puzzle.Characters [1]);
			} else if (numCharacters == 3) {
				characters [0].gameObject.SetActive (false);
				characters [4].gameObject.SetActive (false);
			} else if (numCharacters == 4) {
				characters [2].gameObject.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
