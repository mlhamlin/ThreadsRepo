using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AvatarTestGenderDisplay : UnitySingletonPersistent<AvatarTestGenderDisplay> {

	public void UpdateText(CharacterData cData){
		GetComponent<Text> ().text = cData.gender.TraitName;
	}
}
