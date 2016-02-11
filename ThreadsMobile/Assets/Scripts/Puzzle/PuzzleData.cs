using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleData {

	public string puzzleName;
	public string puzzleDesc;

	public int[] starPointReqs;

	public List<string> characterStrings;

	private List<CharacterData> characters;

	public List<CharacterData> Characters {
		get{
			if (characters != null) {
				return characters;
			} else {
				InitCharacters ();
				return characters;
			}
		}
	}

	private void InitCharacters(){
		characters = new List<CharacterData> ();

		foreach(string cString in characterStrings){
			characters.Add (CharacterManager.GetCharacter (cString));
		}
	}

	public void PrintInfo(){
		string puzzleHeader = "";

		puzzleHeader += puzzleName + '\n';
		puzzleHeader += puzzleDesc + '\n';
		puzzleHeader += "1 Star: " + starPointReqs[0] + " Points" + '\n';
		puzzleHeader += "2 Star: " + starPointReqs[1] + " Points" + '\n';
		puzzleHeader += "3 Star: " + starPointReqs[2] + " Points" + '\n';

		Debug.Log (puzzleHeader);

		foreach(CharacterData cData in Characters){
			cData.PrintInfo ();
		}
	}
}