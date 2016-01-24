using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TraitManager : UnitySingletonPersistent<TraitManager> {

    public struct Trait
    {
        string traitName;
        string traitDescription;
        string icon;

        public Trait(string traitName, string traitDescription, string icon) : this()
        {
            this.traitName = traitName;
            this.traitDescription = traitDescription;
            this.icon = icon;
        }

		public static Trait ErrorTrait(){
			return new Trait("error", "error", "error");
		}
    }

    public Dictionary<int, Trait> traits;
	
	JsonSerializerSettings settings;
	
	public void Start()
	{
		traits = new Dictionary<int, Trait>();
		
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		TextAsset traitsFile = Resources.Load<TextAsset>("Characters/Traits");
		
		Instance.traits = JsonConvert.DeserializeObject<Dictionary<int, Trait>>(traitsFile.text, Instance.settings);
	}

	public static Trait GetTrait(int id){
		Trait value;

		if(Instance.traits.TryGetValue(id, out value)){
			return value;
		}else{
			Debug.LogError("Trait #" + id + " not found");
			return Trait.ErrorTrait();
		}
	}
}
