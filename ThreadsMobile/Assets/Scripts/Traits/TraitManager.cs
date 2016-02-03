using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

public class TraitManager : UnitySingletonPersistent<TraitManager> {

	const string GENDER_PATH = "Characters/Genders";
	const string QUIRK_PATH = "Characters/Quirks";
	const string LIKE_PATH = "Characters/Likes";
	const string DISLIKE_PATH = "Characters/Dislikes";

	public Dictionary<string, Trait> traits;

	ProbabilityArray<Gender> genderProbabilities;
	ProbabilityArray<Quirk> quirkProbabilities;
	ProbabilityArray<Like> likeProbabilities;
	ProbabilityArray<Dislike> dislikeProbabilities;
	
	JsonSerializerSettings settings;
	
	public void Start(){
		LoadAll();

		/* Generator Tests
		Debug.Log(GetRandomGender().TraitName);
		Debug.Log(GetRandomGender().TraitName);
		Debug.Log(GetRandomGender().TraitName);
		Debug.Log(GetRandomGender().TraitName);

		Debug.Log(GetRandomLike().TraitName);
		Debug.Log(GetRandomLike().TraitName);
		Debug.Log(GetRandomLike().TraitName);
		Debug.Log(GetRandomLike().TraitName);

		Debug.Log(GetRandomDislike().TraitName);
		Debug.Log(GetRandomDislike().TraitName);
		Debug.Log(GetRandomDislike().TraitName);
		Debug.Log(GetRandomDislike().TraitName);

		Debug.Log(GetRandomQuirk().TraitName);
		Debug.Log(GetRandomQuirk().TraitName);
		Debug.Log(GetRandomQuirk().TraitName);
		Debug.Log(GetRandomQuirk().TraitName);

		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		Debug.Log(CharacterGenerator.Generate(0).gender.TraitName);
		*/

	}

	#region Loading
	private void LoadAll(){
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;
		
		Dictionary<string, Gender> genders = Load<Gender> (GENDER_PATH);
		Dictionary<string, Quirk> quirks = Load<Quirk> (QUIRK_PATH);
		Dictionary<string, Like> likes = Load<Like> (LIKE_PATH);
		Dictionary<string, Dislike> dislikes = Load<Dislike> (DISLIKE_PATH);

		//Seting up all Probability Arrays
		genderProbabilities = TraitDictionaryToProbabilityArray<Gender>(genders);
		quirkProbabilities = TraitDictionaryToProbabilityArray<Quirk>(quirks);
		likeProbabilities = TraitDictionaryToProbabilityArray<Like>(likes);
		dislikeProbabilities = TraitDictionaryToProbabilityArray<Dislike>(dislikes);
		
		traits = new Dictionary<string, Trait>();

		//Combining each dictionary into the traits master dictionary
		//Duplicate trait keys are not allowed
		genders.ToList().ForEach(entry => traits.Add(entry.Key, entry.Value));
		quirks.ToList().ForEach(entry => traits.Add(entry.Key, entry.Value));
		likes.ToList().ForEach(entry => traits.Add(entry.Key, entry.Value));
		dislikes.ToList().ForEach(entry => traits.Add(entry.Key, entry.Value));
	}

	private Dictionary<string, T> Load<T>(string filePath) where T : Trait {
		TextAsset traitsFile = Resources.Load<TextAsset>(filePath);

		return JsonConvert.DeserializeObject<Dictionary<string, T>>(traitsFile.text, Instance.settings);
	}

	private ProbabilityArray<T> TraitDictionaryToProbabilityArray<T> (Dictionary<string, T> dict) where T : Trait {
		ProbabilityArray<T> array = new ProbabilityArray<T>(); 

		foreach(KeyValuePair<string, T> kvp in dict){
			array.AddValue (kvp.Value, kvp.Value.Weight);
		}

		return array;
	}
	#endregion

	#region Get
	public static T GetTrait<T>(string id) where T : Trait {
		Trait trait = GetTrait(id);

		if(trait is T){
			return (T)trait;
		}else{
			Debug.LogError("Trait '" + trait.TraitName + "' cannot be cast");
			return null;
		}
	}

	public static Trait GetTrait(string id){
		Trait value;

		if(Instance.traits.TryGetValue(id, out value)){
			return value;
		}else{
			Debug.LogError("Trait '" + id + "' not found");
			return Trait.ErrorTrait();
		}
	}

	public static Gender GetRandomGender(){
		return Instance.genderProbabilities.GetRandomValue ();
	}

	public static Quirk GetRandomQuirk(){
		return Instance.quirkProbabilities.GetRandomValue ();
	}

	public static Like GetRandomLike(){
		return Instance.likeProbabilities.GetRandomValue ();
	}

	public static Dislike GetRandomDislike(){
		return Instance.dislikeProbabilities.GetRandomValue ();
	}
	#endregion
}
