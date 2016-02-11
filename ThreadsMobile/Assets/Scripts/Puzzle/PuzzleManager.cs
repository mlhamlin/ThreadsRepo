using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

public class PuzzleManager : UnitySingletonPersistent<PuzzleManager> {

	const string PUZZLE_PATH = "Puzzles/";

	//public Dictionary<string, CharacterData> characters;

	JsonSerializerSettings settings;

	public override void Awake(){
		OnAwake ();
	}

	public static PuzzleData LoadPuzzle(string puzzleName){
		Instance.settings = new JsonSerializerSettings();
		Instance.settings.TypeNameHandling = TypeNameHandling.Objects;

		TextAsset puzzleFile = Resources.Load<TextAsset>(PUZZLE_PATH + puzzleName);

		return JsonConvert.DeserializeObject<PuzzleData>(puzzleFile.text, Instance.settings);
	}
}
