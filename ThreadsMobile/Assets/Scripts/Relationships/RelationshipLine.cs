using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class RelationshipLine : MonoBehaviour
{

    //TODO: Find something to consistently child these too for neatness

    public CharacterInteraction char1;
    public CharacterInteraction char2;
    private Vector3 start;
    private Vector3 end;
    public float LineWidth = .2f;
    public LineRenderer rend;
    public bool set;
    public BoxCollider2D coll;

    public void StartLine(Vector3 point, CharacterInteraction character)
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

    public bool SameStartEnd(CharacterInteraction character)
    {
        return char1 == character;
    }

    public void Finish(Vector3 point, CharacterInteraction character)
    {
        char2 = character;

        if(!ShipManager.NewRomanticShip(char1.data, char2.data))
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
    }

    private void CreateCollider()
    {
        GameObject chi = new GameObject("Collider");
        chi.transform.SetParent(this.transform);
        coll = chi.AddComponent<BoxCollider2D>();

        chi.transform.position = Vector3.Lerp(start, end, .5f);
        Vector3 along = end - start;
        chi.transform.Rotate(0f, 0f, Vector3.Angle(along, Vector3.right));

        coll.size = new Vector2(Vector3.Distance(start, end), LineWidth);
    }
}
