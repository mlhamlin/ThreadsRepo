using UnityEngine;
using System.Collections.Generic;
using TouchScript.Gestures;

public class ShipBreaker : UnitySingleton<ShipBreaker> {
    //aka Canon
    public FlickGesture flick;
    public MetaGesture itsSoMeta;
    public GameObject breaker;

    private List<RelationshipLine> lines;
    private bool flicking;

    public void Awake()
    {
        lines = new List<RelationshipLine>();
        flick.StateChanged += flickStateChange;
        itsSoMeta.TouchBegan += ItsSoMeta_TouchBegan;
        itsSoMeta.TouchMoved += ItsSoMeta_TouchMoved;
        itsSoMeta.TouchEnded += ItsSoMeta_TouchEnded;
        breaker.SetActive(false);
    }

    private void ItsSoMeta_TouchEnded(object sender, MetaGestureEventArgs e)
    {
        flicking = false;
        breaker.SetActive(false);
    }

    private void ItsSoMeta_TouchMoved(object sender, MetaGestureEventArgs e)
    {
        breaker.transform.position = Camera.main.ScreenToWorldPoint(e.Touch.Position);
    }

    private void ItsSoMeta_TouchBegan(object sender, MetaGestureEventArgs e)
    {
        flicking = true;
        breaker.SetActive(true);
    }

    private void flickStateChange(object sender, GestureStateChangeEventArgs e)
    {
        if (e.State == Gesture.GestureState.Recognized)
        {
            Debug.Log("flick indeed");
            DestroyLines();
        }
        else if (e.State == Gesture.GestureState.Failed)
        {
            Debug.Log("flick failed");
            EmptyList();
        }
    }

    private void DestroyLines()
    {
        foreach(RelationshipLine line in lines)
        {
            line.BreakUp();            
        }
        EmptyList();
    }

    public static void SetFriendly(Gesture gest)
    {
        gest.AddFriendlyGesture(Instance.flick);
    }

    public static void Register(RelationshipLine line)
    {
        if (Instance.flicking && !Instance.lines.Contains(line))
        {
            Instance.lines.Add(line);
        }
    }

    private void EmptyList()
    {
        lines.Clear();
    }

}
