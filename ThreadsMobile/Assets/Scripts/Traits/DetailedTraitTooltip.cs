using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetailedTraitTooltip : UnitySingleton<DetailedTraitTooltip> {

	public GameObject toolTip;
	public GameObject traitIcon;
	public GameObject traitName;
	public GameObject traitDesc;

	public void setupToolTip(Trait trait) {
		toolTip.SetActive (true);

		traitIcon.GetComponent<Image> ().sprite = trait.Icon;
		traitName.GetComponent<Text> ().text = trait.TraitName;
		traitDesc.GetComponent<Text> ().text = trait.TraitDescription;
	}
}
