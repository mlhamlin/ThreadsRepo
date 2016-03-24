using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class AvatarTestFaceCounter : MonoBehaviour {

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		//text.text = AvatarGenerator.Instance.CountCombinations() + " unique faces";
		float faces = AvatarGenerator.Instance.CountCombinations()/1000000000000f;
		text.text = "~" + string.Format("{0:n0}", faces) + " trillion unique faces";
	}
}
