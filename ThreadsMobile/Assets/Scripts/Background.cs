using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Behaviors;

public class Background : UnitySingleton<Background> {

    private TapGesture tapBack;

    private void Start()
    {
        tapBack = gameObject.GetComponent<TapGesture>();
    }
}
