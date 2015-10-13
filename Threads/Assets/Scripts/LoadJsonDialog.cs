using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class LoadJsonDialog : MonoBehaviour {

    bool DoneIt = false;

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
	    if (!DoneIt)
        {
            DialogDictionary.SaveDictionary();
            DoneIt = true;
        }
	}
}
