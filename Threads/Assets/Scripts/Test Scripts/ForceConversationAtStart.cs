using UnityEngine;
using System.Collections;

public class ForceConversationAtStart : MonoBehaviour {

    public string start = "HuyuStart";
    private bool said = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(!said)
        {
            DialogDictionary.GetNode(start).DisplayDialog();
            said = true;
        }
    }
}
