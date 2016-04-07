using UnityEngine;
using System.Collections;

public class PuzzleMenuButtons : MonoBehaviour {

	public void setGamePuzzleName(string name) {
		GameManager.Instance.setPuzzleName (name);
	}
}
