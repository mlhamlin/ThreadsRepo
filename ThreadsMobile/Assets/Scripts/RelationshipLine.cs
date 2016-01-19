using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LineRenderer))]
public class RelationshipLine : MonoBehaviour {

    public CharacterInteraction char1;
    public CharacterInteraction char2;
    public LineRenderer rend;

    public void StartLine(Vector3 point, CharacterInteraction character)
    {
        char1 = character;
        point.z = 0f;
        rend.SetPosition(0, point);
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
        point.z = 0f;
        rend.SetPosition(1, point);
    }
}
