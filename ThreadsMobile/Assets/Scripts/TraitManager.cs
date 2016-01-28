using UnityEngine;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class TraitManager : UnitySingletonPersistent<TraitManager> {

	/*
    public struct Trait
    {
		const string ICON_PATH = "Icons/";

        string traitName;
        string traitDescription;
        string icon;

		public string TraitName {
			get{ return traitName; }
		}

		public string TraitDescription {
			get{ return traitDescription; }
		}

		public Sprite Icon {
			get{ return Resources.Load<Sprite> (ICON_PATH + icon); }
		}

        public Trait(string traitName, string traitDescription, string icon) : this()
        {
            this.traitName = traitName;
            this.traitDescription = traitDescription;
            this.icon = icon;
        }

		public static Trait ErrorTrait(){
			return new Trait("error", "error", "error");
		}
    }*/

    public Dictionary<string, Trait> traits;
	
	JsonSerializerSettings settings;
	
	public void Start()
	{
		traits = new Dictionary<string, Trait>();
		
		settings = new JsonSerializerSettings();
		settings.TypeNameHandling = TypeNameHandling.Objects;

		TextAsset traitsFile = Resources.Load<TextAsset>("Characters/Traits");
		
		Instance.traits = JsonConvert.DeserializeObject<Dictionary<string, Trait>>(traitsFile.text, Instance.settings);
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
}
