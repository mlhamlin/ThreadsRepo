using UnityEngine;
using System.Collections;

public class GameManager : UnitySingletonPersistent<GameManager> {

	private string puzzleType;
	private string puzzleName;

	public override void Awake(){
		OnAwake ();
	}

	public void setPuzzleType(string type) {
		puzzleType = type;
	}

	public void setPuzzleName(string name) {
		puzzleName = name;
	}

	public string getPuzzleType() {
		return puzzleType;
	}

	public string getPuzzleName() {
		return puzzleName;
	}
}
