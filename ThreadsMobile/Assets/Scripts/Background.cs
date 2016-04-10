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
        tapBack.Tapped += TapBack_Tapped;
        tapBack.StateChanged += TapBack_StateChanged;
    }

    private void TapBack_StateChanged(object sender, GestureStateChangeEventArgs e)
    {
        Debug.Log("state changed on back: " + e.State);
    }

    private void TapBack_Tapped(object sender, System.EventArgs e)
    {
        Debug.Log("TAPED!");
    }
}
