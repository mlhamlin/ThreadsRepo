using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TraitManager : UnitySingletonPersistent<TraitManager> {

    public Dictionary<string, Trait> traits;

	ProbabilityArray<Trait> traitProbabilities;
	
	JsonSerializerSettings settings;
	
	public void Start()
	{
		traits = new Dictionary<string, Trait>();
		
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		TextAsset traitsFile = Resources.Load<TextAsset>("Characters/Traits");
		
		Instance.traits = JsonConvert.DeserializeObject<Dictionary<string, Trait>>(traitsFile.text, Instance.settings);

		SetupTraitProbabilities ();
	}

	private void SetupTraitProbabilities(){
		traitProbabilities = new ProbabilityArray<Trait> ();

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
