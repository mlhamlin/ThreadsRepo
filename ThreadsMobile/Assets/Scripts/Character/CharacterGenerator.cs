using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterGenerator {

	const int GENDER_LIMIT = 1;
	const int QUIRK_LIMIT = 5;
	const int LIKE_LIMIT = 3;
	const int DISLIKE_LIMIT = 2;

	public static CharacterData Generate(){
		CharacterData cData = new CharacterData();

		cData.seed = Random.seed;

		cData.gender = TraitManager.GetRandomGender();

		cData.quirks = new List<Quirk>();
		for(int i = 0; i <= QUIRK_LIMIT; i++){
			cData.quirks.Add(TraitManager.GetRandomQuirk());
		}

		cData.likes = new List<Like>();
		for(int i = 0; i <= LIKE_LIMIT; i++){
			cData.likes.Add(TraitManager.GetRandomLike());
		}

		cData.dislikes = new List<Dislike>();
		for(int i = 0; i <= DISLIKE_LIMIT; i++){
			cData.dislikes.Add(TraitManager.GetRandomDislike());
		}

		return cData;
	}

	public static CharacterData Generate(int seed){
		Random.seed = seed;

		return Generate();
	}
}
