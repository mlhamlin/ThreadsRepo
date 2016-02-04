using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent(typeof(LineRenderer))]
public class RelationshipLine : MonoBehaviour
{

    public CharacterCore char1;
    public CharacterCore char2;
    private Vector3 start;
    private Vector3 end;
    public float LineWidth = .2f;
    public LineRenderer rend;
    public bool set;
    public BoxCollider2D coll;

    public void StartLine(Vector3 point, CharacterCore character)
    {
        rend.SetWidth(LineWidth, LineWidth);
        char1 = character;
        point.z = 0f;
        rend.SetPosition(0, point);
        start = point;
    }

    public void UpdateEnd(Vector3 point)
    {
        point.z = 0f;
        rend.SetPosition(1, point);
    }

    public bool SameStartEnd(CharacterCore character)
    {
        return char1 == character;
    }

    public void Finish(Vector3 point, CharacterCore character)
    {
        char2 = character;

        if(!ShipManager.NewRomanticShip(char1, char2))
        {
            //if this relationship already exists destroy the new one
            GameObject.Destroy(this.gameObject);
            return;
        }

        point.z = 0f;
        rend.SetPosition(1, point);
        end = point;
        gameObject.name = char1.name + "/" + char2.name;

        CreateCollider();

        set = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LineBreaker")
        {
            ShipBreaker.Register(this);
        }
    }

    public void BreakUp()
    {
        ShipManager.ProcessBreakup(char1, char2);
        Destroy(gameObject);
    }

    private void CreateCollider()
    {
        coll.transform.position = Vector3.Lerp(start, end, .5f);

        Vector3 along = new Vector3();

        //since Vector3.Angle clamps it's value make it so
        // we do this math magic to avoid needing the full 360 degrees
        if (start.y > end.y)
        {
            along = start - end;
        }
        else
        {
            along = end - start;
        }

        coll.transform.Rotate(0f, 0f, Vector3.Angle(along, Vector3.right));

        coll.size = new Vector2(Vector3.Distance(start, end), LineWidth);
    }


}
