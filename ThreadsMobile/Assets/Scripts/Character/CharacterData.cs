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
}
