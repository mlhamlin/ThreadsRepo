using UnityEngine;
using System.Collections;

public class Trait {

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

	public Trait(){
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
}
