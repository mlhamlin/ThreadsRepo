using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

public class CharacterManager : UnitySingletonPersistent<CharacterManager> {

	const string CHARACTER_PATH = "Characters/Characters";

	public Dictionary<string, CharacterData> characters;

	JsonSerializerSettings settings;

	public override void Awake(){
		OnAwake ();
		LoadAll ();

		//PuzzleManager.LoadPuzzle ("Metalocalypse").PrintInfo();
	}

	private void LoadAll(){
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		TextAsset charactersFile = Resources.Load<TextAsset>(CHARACTER_PATH);

		Dictionary<string, CharacterDataFromJSON> charsFromJSON = JsonConvert.DeserializeObject<Dictionary<string, CharacterDataFromJSON>>(charactersFile.text, Instance.settings);
		characters = new Dictionary<string, CharacterData> ();

		foreach(KeyValuePair<string, CharacterDataFromJSON> kvp in charsFromJSON){
			characters.Add (kvp.Key, kvp.Value.ToCharacterData ());
		}
	}

	public static CharacterData GetCharacter(string id){
		CharacterData value;

		if(Instance.characters.TryGetValue(id, out value)){
			return value;
		}else{
			Debug.LogError("Character '" + id + "' not found");
			return new CharacterData();
		}
	}

}
