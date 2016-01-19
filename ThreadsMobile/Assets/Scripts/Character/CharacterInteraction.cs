using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;

[RequireComponent(typeof(PressGesture), typeof(ReleaseGesture))]
public class CharacterInteraction : MonoBehaviour {

    public GameObject UI;
    public GameObject Background;
    public CharacterData data;
    private PressGesture press;
    private MetaGesture metaGestures;
    private ReleaseGesture release;

    private TapGesture tapBack;

    public GameObject linePrefab;
    private RelationshipLine currentLine;
    private bool DrawingLine;


    // Use this for initialization
    void Start () {
    }

    private void OnEnable()
    {
        press = GetComponent<PressGesture>();
        metaGestures = GetComponent<MetaGesture>();
        release = GetComponent <ReleaseGesture>();
        tapBack = Background.GetComponent<TapGesture>();

        press.Pressed += PressHandler;
    }

    private void OnDisable()
    {
        press.Pressed -= PressHandler;
    }
    
    //clean this up with helpers as well
    private void PressHandler(object sender, EventArgs e)
    {
        DrawingLine = true;

        PressGesture gesture = sender as PressGesture;
        TouchHit hit;
        gesture.GetTargetHitResult(out hit);
        GameObject hitObj = hit.RaycastHit2D.transform.gameObject;

        GameObject obj = Instantiate<GameObject>(linePrefab);
        currentLine = obj.GetComponent<RelationshipLine>();
        currentLine.StartLine(hitObj.transform.position, this);
        currentLine.UpdateEnd(hit.Transform.position);

        release.Released += ReleaseHandler;
        metaGestures.TouchMoved += movingTouchHandler;
    }

    private void movingTouchHandler(object sender, MetaGestureEventArgs e)
    {
        TouchScript.TouchPoint point = e.Touch;
        Vector2 ScreenLoc = point.Position;
        currentLine.UpdateEnd(Camera.main.ScreenToWorldPoint(new Vector3(ScreenLoc.x, ScreenLoc.y, -1f)));
    }

    //clean this up in helpers etc
    private void ReleaseHandler(object sender, EventArgs e)
    {
        if(DrawingLine)
        {
            ReleaseGesture gesture = sender as ReleaseGesture;
            TouchHit hit;
            gesture.GetTargetHitResult(out hit);
            GameObject hitObj = hit.RaycastHit2D.transform.gameObject;
            if(hitObj.tag == "Character")
            {
                CharacterInteraction character = hitObj.GetComponent<CharacterInteraction>();
                if (currentLine.SameStartEnd(character))
                {
                    UI.SetActive(true);
                    tapBack.Tapped += tapBackHandler;
                    Destroy(currentLine.gameObject);
                }
                else
                {
                    currentLine.Finish(hitObj.transform.position, character);
                }
            }
            else
            {
                Destroy(currentLine.gameObject);
            }

            release.Released -= ReleaseHandler;
            metaGestures.TouchMoved -= movingTouchHandler;

            DrawingLine = false;
        }
    }

    private void tapBackHandler(object sender, EventArgs e)
    {
        UI.SetActive(false);
        tapBack.Tapped -= tapBackHandler;
    }

}
