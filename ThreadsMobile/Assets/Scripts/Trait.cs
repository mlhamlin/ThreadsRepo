using UnityEngine;
using System.Collections;

public class Trait {

	const string ICON_PATH = "Icons/";

	string traitName;
	string traitDescription;
	string icon;

	float weight;

	public string TraitName {
		get{ return traitName; }
	}

	public string TraitDescription {
		get{ return traitDescription; }
	}

	public Sprite Icon {
		get{ return Resources.Load<Sprite> (ICON_PATH + icon); }
	}

	public float Weight {
		get { return weight; }
	}

	public Trait(string traitName, string traitDescription, string icon, int weight){
		this.traitName = traitName;
		this.traitDescription = traitDescription;
		this.icon = icon;
		this.weight = weight;
	}

	public static Trait ErrorTrait(){
		return new Trait("error", "error", "error", 0);
	}
}
