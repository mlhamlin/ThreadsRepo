using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TraitManager : UnitySingletonPersistent<TraitManager> {

	const string GENDER_PATH = "Characters/Genders";
	const string QUIRK_PATH = "Characters/Quirks";
	const string LIKE_PATH = "Characters/Likes";
	const string DISLIKE_PATH = "Characters/Dislikes";

	public Dictionary<string, Gender> genders;
	public Dictionary<string, Quirk> quirks;
	public Dictionary<string, Like> likes;
	public Dictionary<string, Dislike> dislikes;

	ProbabilityArray<Gender> genderProbabilities;
	ProbabilityArray<Quirk> quirkProbabilities;
	ProbabilityArray<Like> likeProbabilities;
	ProbabilityArray<Dislike> dislikeProbabilities;
	
	JsonSerializerSettings settings;
	
	public void Start(){
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		LoadTraits ();
		SetupTraitProbabilities ();
	}

	private Dictionary<string, T> Load<T>(){
		TextAsset traitsFile = Resources.Load<TextAsset>("Characters/Traits");

		Instance.traits = JsonConvert.DeserializeObject<Dictionary<string, Trait>>(traitsFile.text, Instance.settings);
	}

	private void SetupTraitProbabilities(){
		genderProbabilities = new ProbabilityArray<Gender> ();
		quirkProbabilities = new ProbabilityArray<Quirk> ();
		likeProbabilities = new ProbabilityArray<Like> ();
		dislikeProbabilities = new ProbabilityArray<Dislike> ();

		foreach(KeyValuePair<string, Trait> kvp in traits){
			traitProbabilities.AddValue (kvp.Value, kvp.Value.Weight);
		}
	}

	public static Trait GetTrait(string id){
		Trait value;

		if(Instance.traits.TryGetValue(id, out value)){
			return value;
		}else{
			Debug.LogError("Trait " + id + " not found");
			return Trait.ErrorTrait();
		}
	}

	public static Trait GetRandomTrait(){
		return Instance.traitProbabilities.GetRandomValue ();
	}
}
