using UnityEngine;
using System.Collections.Generic;

public class CharacterData {

	public int seed;

    public Gender gender;

    public List<Quirk> quirks;
    public List<Like> likes;
    public List<Dislike> dislikes;

	//TODO: Add face data


	public CharacterData(){
	}

	public CharacterData(Gender gender, List<Quirk> quirks, List<Like> likes, List<Dislike> dislikes){
		this.gender = gender;
		this.quirks = quirks;
		this.likes = likes;
		this.dislikes = dislikes;
	}

	public List<Trait> GetAllTraits(){
		List<Trait> traits = new List<Trait> ();

		traits.Add (gender);
		foreach(Quirk q in quirks){
			traits.Add (q);
		}

		foreach(Like l in likes){
			traits.Add (l);
		}

		foreach(Dislike d in dislikes){
			traits.Add (d);
		}

		return traits;
	}

	public bool ContainsTrait(Trait trait){
		foreach(Trait localTrait in GetAllTraits()){
			if(localTrait.TraitName == trait.TraitName){
				return true;
			}
		}

		return false;
	}

	public int ScoreRelationship(CharacterData other){
		int totalScore = 0;

		foreach(Trait t in GetAllTraits()){
			totalScore += t.Score (other);
		}

		return totalScore;
	}
}
