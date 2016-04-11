using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Behaviors;

public class Background : UnitySingleton<Background> {

    private TapGesture tapBack;

    public static TapGesture getTapGesture()
    {
        return Instance.tapBack;
    }

    private void Awake()
    {
        tapBack = gameObject.GetComponent<TapGesture>();
    }
}
