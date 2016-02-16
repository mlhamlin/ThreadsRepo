using UnityEngine;
using System.Collections;

public class BlockOnDebug : MonoBehaviour {

    public GameObject Blocker;
    public Reporter rep;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Blocker.SetActive(rep.show);
	}
}
