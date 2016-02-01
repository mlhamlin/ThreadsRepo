using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trait {

	protected const string ICON_PATH = "Icons/";

	string traitName;
	string traitDescription;
	string icon;

	float weight;

	List<string> conflicts;
	Dictionary<string, int> scoring;

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

	public Trait(string traitName, string traitDescription, string icon, int weight, List<string> conflicts = null, Dictionary<string, int> scoring = null){
		this.traitName = traitName;
		this.traitDescription = traitDescription;
		this.icon = icon;
		this.weight = weight;
		this.conflicts = conflicts;
		this.scoring = scoring;
	}

	public static Trait ErrorTrait(){
		return new Trait("error", "error", "error", 0);
	}
}

public class Gender : Trait {
	public Gender(string traitName, string traitDescription, string icon, int weight, List<string> conflicts = null, Dictionary<string, int> scoring = null)
		: base(traitName, traitDescription, icon, weight, conflicts, scoring){
	}
}

public class Quirk : Trait {
	public Quirk(string traitName, string traitDescription, string icon, int weight, List<string> conflicts = null, Dictionary<string, int> scoring = null)
		: base(traitName, traitDescription, icon, weight, conflicts, scoring){
	}
}

public class Like : Trait {
	public Like(string traitName, string traitDescription, string icon, int weight, List<string> conflicts = null, Dictionary<string, int> scoring = null)
		: base(traitName, traitDescription, icon, weight, conflicts, scoring){
	}
}

public class Dislike : Trait {
	public Dislike(string traitName, string traitDescription, string icon, int weight, List<string> conflicts = null, Dictionary<string, int> scoring = null)
		: base(traitName, traitDescription, icon, weight, conflicts, scoring){
	}
}
