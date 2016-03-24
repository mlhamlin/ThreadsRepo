using UnityEngine;
using System.Collections.Generic;

public class CharacterData {

	public int seed;

	public string firstName;
	public string lastName;
	public string description;

    public Gender gender;

    public List<Quirk> quirks;
    public List<Like> likes;
    public List<Dislike> dislikes;

	public AvatarData avatar;

	#region Constructors
	public CharacterData(){
	}

	public CharacterData(Gender gender, List<Quirk> quirks, List<Like> likes, List<Dislike> dislikes){
		this.gender = gender;
		this.quirks = quirks;
		this.likes = likes;
		this.dislikes = dislikes;
	}

	public CharacterData(string firstName, string lastName, string desc, string gender, List<string> quirks, List<string> likes, List<string> dislikes){
		this.firstName = firstName;
		this.lastName = lastName;
		this.description = desc;

		this.gender = TraitManager.GetTrait<Gender>(gender);

		this.quirks = new List<Quirk> ();
		foreach(string s in quirks){
			this.quirks.Add (TraitManager.GetTrait<Quirk>(s));
		}

		this.likes = new List<Like> ();
		foreach(string s in likes){
			this.likes.Add (TraitManager.GetTrait<Like>(s));
		}

		this.dislikes = new List<Dislike> ();
		foreach(string s in dislikes){
			this.dislikes.Add (TraitManager.GetTrait<Dislike>(s));
		}
	}
	#endregion

	public List<Trait> GetAllTraits(){
		List<Trait> traits = new List<Trait> ();

        if (gender != null)
        {
            traits.Add(gender);
        }

        if (quirks != null)
        {
            foreach(Quirk q in quirks)
            {
                traits.Add(q);
            }
        }

        if(likes != null)
        {
            foreach(Like l in likes)
            {
                traits.Add(l);
            }
        }
		
        if (dislikes != null)
        {
            foreach(Dislike d in dislikes)
            {
                traits.Add(d);
            }
        }

		return traits;
	}

	public bool ContainsTrait(string id){
		return ContainsTrait (TraitManager.GetTrait (id));
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

	public int GetMaximumScore(){
		int totalScore = 0;

		foreach(Trait t in GetAllTraits()){
			totalScore += t.GetMaximumScore ();
		}

		return totalScore;
	}

	public int GetMinimumScore(){
		int totalScore = 0;

		foreach(Trait t in GetAllTraits()){
			totalScore += t.GetMinimumScore ();
		}

		return totalScore;
	}

	public void PrintInfo(){
		string characterInfo = "";

		characterInfo += firstName + " " + lastName + '\n';
		characterInfo += description + '\n';
		characterInfo += gender.TraitName + '\n';

		foreach(Trait t in quirks){
			characterInfo += t.TraitName + '\n';
		}

		foreach(Trait t in dislikes){
			characterInfo += t.TraitName + '\n';
		}

		foreach(Trait t in likes){
			characterInfo += t.TraitName + '\n';
		}

		Debug.Log (characterInfo);
	}
}

public class CharacterDataFromJSON {
	public string firstName;
	public string lastName;
	public string desc;

	public string gender;
	public List<string> quirks;
	public List<string> likes;
	public List<string> dislikes;

	public CharacterData ToCharacterData(){
		return new CharacterData (firstName, lastName, desc, gender, quirks, likes, dislikes);
	}
}
