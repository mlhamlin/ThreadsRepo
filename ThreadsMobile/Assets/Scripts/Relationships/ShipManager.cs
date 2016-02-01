using UnityEngine;
using System.Collections.Generic;

public class ShipManager : UnitySingleton<ShipManager> {

    public static bool NewPlatonicShip(CharacterData a, CharacterData b)
    {
        return NewShipListUpdate(a, a.PlatonicPartners, b, b.PlatonicPartners);
    }

    public static bool NewRomanticShip(CharacterData a, CharacterData b)
    {
        return NewShipListUpdate(a, a.RomanticPartners, b, b.RomanticPartners);
    }

    public static bool NewSexualShip(CharacterData a, CharacterData b)
    {
        return NewShipListUpdate(a, a.SexualPartners, b, b.SexualPartners);
    }

    private static bool NewShipListUpdate(CharacterData a, List<CharacterData> alist,
        CharacterData b, List<CharacterData> blist)
    {
        if(alist.Contains(b) || blist.Contains(a))
            return false;

        alist.Add(b);
        blist.Add(a);
        Merge(a.currentShipWeb, b.currentShipWeb);

        return true;
    }

    public static void Merge(RelationshipWeb a, RelationshipWeb b)
    {
        if(a == b)
            return;

        foreach(CharacterData chr in b.members)
        {
            chr.currentShipWeb = a;
            a.members.Add(chr);
        }

        GameObject.Destroy(b.gameObject);
    }

    public static void ProcessBreakup(CharacterData a, CharacterData b)
    {
        a.RomanticPartners.Remove(b);
        b.RomanticPartners.Remove(a);

        RelationshipWeb oldWeb = a.currentShipWeb;
        Destroy(oldWeb.gameObject);

        Populate(SetUpWeb(), a);

        if (b.currentShipWeb != a.currentShipWeb)
        {
            Populate(SetUpWeb(), b);
        }
    }

    public static void Populate(RelationshipWeb web, CharacterData chr)
    {
        if(web.members.Contains(chr))
            return;

        web.members.Add(chr);
        chr.currentShipWeb = web;

        foreach(CharacterData partner in chr.PlatonicPartners)
        {
            Populate(web, partner);
        }

        foreach(CharacterData partner in chr.SexualPartners)
        {
            Populate(web, partner);
        }

        foreach(CharacterData partner in chr.RomanticPartners)
        {
            Populate(web, partner);
        }
    }

    public static RelationshipWeb SetUpWeb()
    {
        GameObject Relationship = new GameObject("ShipWeb");
        Relationship.transform.SetParent(Instance.transform);
        RelationshipWeb web = Relationship.AddComponent<RelationshipWeb>();
        web.members = new List<CharacterData>();
        return web;
    }
}
