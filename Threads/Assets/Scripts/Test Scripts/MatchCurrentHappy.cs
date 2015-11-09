using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MatchCurrentHappy : MonoBehaviour {

    public Text points;
	
	// Update is called once per frame
	void Update () {
        points.text = RelationshipNetwork.Instance.CurrentNetHappiness.ToString();
	}
}
