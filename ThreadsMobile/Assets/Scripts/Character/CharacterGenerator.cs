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
		for(int i = 0; i < QUIRK_LIMIT; i++){
            Quirk qrk = GenerateQuirk(cData);
            if (qrk != null)
                cData.quirks.Add(qrk);
		}

		cData.likes = new List<Like>();
		for(int i = 0; i < LIKE_LIMIT; i++){
            Like lk = GenerateLike(cData);
            if(lk != null)
                cData.likes.Add(lk);
		}

		cData.dislikes = new List<Dislike>();
		for(int i = 0; i < DISLIKE_LIMIT; i++){
            Dislike dslk = GenerateDislike(cData);
            if(dslk != null)
                cData.dislikes.Add(dslk);
		}

		return cData;
	}

	public static CharacterData Generate(int seed){
		Random.seed = seed;

		return Generate();
	}

	#region Trait Generation
	static Quirk GenerateQuirk(CharacterData character, int timeout = 20){
		Quirk q = TraitManager.GetRandomQuirk ();

		if (!q.ConflictsWith (character)) {
			return q;
		} else if (timeout > 0) {
			return GenerateQuirk (character, timeout - 1);
		} else {
			Debug.LogWarning ("Quirk Generation timed out");
			return null;
		}
	}

	static Like GenerateLike(CharacterData character, int timeout = 20){
		Like l = TraitManager.GetRandomLike ();

		if (!l.ConflictsWith (character)) {
			return l;
		} else if (timeout > 0) {
			return GenerateLike (character, timeout - 1);
		} else {
			Debug.LogWarning("Like Generation timed out");
			return null;
		}
	}

	static Dislike GenerateDislike(CharacterData character, int timeout = 20){
		Dislike d = TraitManager.GetRandomDislike ();

		if (!d.ConflictsWith (character)) {
			return d;
		} else if (timeout > 0) {
			return GenerateDislike (character, timeout - 1);
		} else {
			Debug.LogWarning ("Dislike Generation timed out");
			return null;
		}
	}
	#endregion
}
