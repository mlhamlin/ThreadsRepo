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

	int mono = 0;
	int poly = 0;

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

	public bool ConflictsWith(CharacterData character){
		if(character.ContainsTrait(this)){
			return true;
		}

        if (conflicts != null)
        {
            foreach(string con in conflicts)
            {
                if(character.ContainsTrait(TraitManager.GetTrait(con)))
                {
                    return true;
                }
            }
        }

		return false;
	}

	public int Score(CharacterData character){
		if(scoring == null){
			return 0;
		}

		int totalScore = 0;

		foreach(Trait t in character.GetAllTraits()){
			if(scoring.ContainsKey(t.traitName)){
				int score = 0;
				scoring.TryGetValue (t.traitName, out score);
				totalScore += score;
			}
		}

		return totalScore;
	}

	public int ScoreMonoPoly(int numPartners){
		if (numPartners > 2) {
			return poly;
		} else {
			return mono;
		}
	}

	public int GetMaximumScore(){
		int score = 0;

		foreach(KeyValuePair<string, int> kvp in scoring){
			score += Mathf.Max (0, kvp.Value);
		}

		return score;
	}

	public int GetMinimumScore(){
		int score = 0;

		foreach(KeyValuePair<string, int> kvp in scoring){
			score += Mathf.Min (0, kvp.Value);
		}

		return score;
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
