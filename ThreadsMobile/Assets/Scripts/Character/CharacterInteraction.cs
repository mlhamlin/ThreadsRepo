using UnityEngine;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript.Hit;
using System;

[RequireComponent(typeof(PressGesture), typeof(ReleaseGesture))]
public class CharacterInteraction : MonoBehaviour {

    public GameObject UI;
    public TraitToolTipData ToolTip;

    private GameObject background;
    private CharacterCore charCore;
    private CharacterData data;
    private PressGesture press;
    private MetaGesture metaGestures;
    private ReleaseGesture release;

    private TapGesture tapBack;

    public GameObject linePrefab;
    private RelationshipLine currentLine;
    private bool DrawingLine;

    public List<TraitInteraction> Quirks;
    public List<TraitInteraction> Likes;
    public List<TraitInteraction> Dislikes;
    public TraitInteraction Gender;


    // Use this for initialization
    void Start () {
    }

    public void Setup(CharacterCore core, CharacterData data)
    {
        this.data = data;
        charCore = core;

        Gender.Setup(core, ToolTip, data.gender);

        for(int i = 0; i < Quirks.Count; i++)
        {
            Quirks[i].Setup(core, ToolTip, data.quirks[i]);
        }

        for(int i = 0; i < Likes.Count; i++)
        {
            Likes[i].Setup(core, ToolTip, data.likes[i]);
        }

        for(int i = 0; i < Dislikes.Count; i++)
        {
            Dislikes[i].Setup(core, ToolTip, data.dislikes[i]);
        }

        OnEnable();
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
        if(DrawingLine)
            return;

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

        Debug.Log("press");
    }

    private void movingTouchHandler(object sender, MetaGestureEventArgs e)
    {
        if (DrawingLine)
        {
            TouchScript.TouchPoint point = e.Touch;
            Vector2 ScreenLoc = point.Position;
            currentLine.UpdateEnd(Camera.main.ScreenToWorldPoint(new Vector3(ScreenLoc.x, ScreenLoc.y, -1f)));
        }
    }

    //clean this up in helpers etc
    private void ReleaseHandler(object sender, EventArgs e)
    {
        Debug.Log("release");
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
                    Debug.Log("just UI clicking");
                    UI.SetActive(true);
                    tapBack.Tapped += tapBackHandler;
                    Destroy(currentLine.gameObject);
                }
                else
                {
                    Debug.Log("making a line");
                    currentLine.Finish(hitObj.transform.position, core);
                    currentLine = null;
                }
            }
            else
            {
                Debug.Log("Didn't hit a character");
                Destroy(currentLine.gameObject);
            }

            release.Released -= ReleaseHandler;
            metaGestures.TouchMoved -= movingTouchHandler;

            DrawingLine = false;
        } else if (currentLine != null) {
            Destroy(currentLine.gameObject);
        }


    }

    private void tapBackHandler(object sender, EventArgs e)
    {
        UI.SetActive(false);
        tapBack.Tapped -= tapBackHandler;
    }

}
