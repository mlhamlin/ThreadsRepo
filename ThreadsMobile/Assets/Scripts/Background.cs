using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Background : UnitySingleton<Background> {

    private TapGesture tapBack;

    // Use this for initialization
    void Start () {
        tapBack = gameObject.GetComponent<TapGesture>();
    }
}
