using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Background : UnitySingleton<Background> {
    private TapGesture tapBack;

    // Use this for initialization
    void Start () {
        tapBack = gameObject.GetComponent<TapGesture>();
        //tapBack.Tapped += TapBack_Tapped;
    }

    private void TapBack_Tapped(object sender, System.EventArgs e)
    {
        Debug.Log("tapped back!");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
