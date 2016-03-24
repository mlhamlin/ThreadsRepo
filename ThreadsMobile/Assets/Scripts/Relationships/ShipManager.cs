using UnityEngine;
using System.Collections.Generic;

public class ShipManager : UnitySingleton<ShipManager> {


    public static bool NewShip(CharacterCore a, CharacterCore b)
    {
        if(a.Partners.Contains(b) || b.Partners.Contains(a))
            return false;

        a.Partners.Add(b);
        b.Partners.Add(a);
        Merge(a.currentShipWeb, b.currentShipWeb);

        UpdateScores(a.currentShipWeb);

        return true;
    }

    public static void Merge(RelationshipWeb a, RelationshipWeb b)
    {
        if(a == b)
            return;

        foreach(CharacterCore chr in b.members)
        {
            chr.currentShipWeb = a;
            a.members.Add(chr);
        }

        GameObject.Destroy(b.gameObject);
    }

    public static void ProcessBreakup(CharacterCore a, CharacterCore b)
    {
        a.Partners.Remove(b);
        b.Partners.Remove(a);

        RelationshipWeb oldWeb = a.currentShipWeb;
        Destroy(oldWeb.gameObject);

        Populate(SetUpWeb(), a);

        UpdateScores(a.currentShipWeb);

        if(b.currentShipWeb != a.currentShipWeb)
        {
            Populate(SetUpWeb(), b);
            UpdateScores(b.currentShipWeb);
        }
    }

    public static void Populate(RelationshipWeb web, CharacterCore chr)
    {
        if(web.members.Contains(chr))
            return;

        web.members.Add(chr);
        chr.currentShipWeb = web;

        foreach(CharacterCore partner in chr.Partners)
        {
            Populate(web, partner);
        }
    }

    public static RelationshipWeb SetUpWeb()
    {
        GameObject Relationship = new GameObject("ShipWeb");
        Relationship.transform.SetParent(Instance.transform);
        RelationshipWeb web = Relationship.AddComponent<RelationshipWeb>();
        web.members = new List<CharacterCore>();
        return web;
    }

    public static void UpdateScores(RelationshipWeb web)
    {
        foreach(CharacterCore chr in web.members)
        {
            chr.ScoreRelationships();
        }
    }
}
