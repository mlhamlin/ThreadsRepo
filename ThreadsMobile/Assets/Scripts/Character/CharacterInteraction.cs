using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;

[RequireComponent(typeof(PressGesture), typeof(ReleaseGesture))]
public class CharacterInteraction : MonoBehaviour {

    public GameObject UI;
    private GameObject background;
    private CharacterCore charCore;
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

    public void SetExternalConnections(CharacterCore core)
    {
        charCore = core;
    }

    private void OnEnable()
    {
        if (background == null)
            background = Background.Instance.gameObject;

        press = GetComponent<PressGesture>();
        metaGestures = GetComponent<MetaGesture>();
        release = GetComponent <ReleaseGesture>();
        tapBack = background.GetComponent<TapGesture>();

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
        currentLine.StartLine(hitObj.transform.position, charCore);
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
                CharacterCore core = hitObj.GetComponent<CharacterCore>();
                if (currentLine.SameStartEnd(core))
                {
                    UI.SetActive(true);
                    tapBack.Tapped += tapBackHandler;
                    Destroy(currentLine.gameObject);
                }
                else
                {
                    currentLine.Finish(hitObj.transform.position, core);
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
