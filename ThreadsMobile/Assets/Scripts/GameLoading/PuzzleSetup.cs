using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PuzzleSetup : MonoBehaviour {

	public CharacterCore character1;
	public CharacterCore character2;
	public CharacterCore character3;
	public CharacterCore character4;
	public CharacterCore character5;

	// Use this for initialization
	void Start () {
		if (GameManager.Instance.getPuzzleType () == "Random") {
			character1.setCharacterData (null);
			character2.setCharacterData (null);
			character3.setCharacterData (null);
			character4.setCharacterData (null);
			character5.setCharacterData (null);
		} else if (GameManager.Instance.getPuzzleType () == "Campaign") {
			PuzzleData puzzle = PuzzleManager.LoadPuzzle (GameManager.Instance.getPuzzleName ());
			int numCharacters = puzzle.Characters.Count;
			if (numCharacters == 2) {
				Destroy (character1.gameObject);
				Destroy (character3.gameObject);
				Destroy (character4.gameObject);

				character2.setCharacterData (puzzle.Characters [0]);
				character5.setCharacterData (puzzle.Characters [1]);
			} else if (numCharacters == 3) {
				Destroy (character1.gameObject);
				Destroy (character5.gameObject);
			} else if (numCharacters == 4) {
				Destroy (character3.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
