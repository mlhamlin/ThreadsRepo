using UnityEngine;
using System.Collections;

public class WebManager : UnitySingleton<WebManager> {

    public static void Merge(RelationshipWeb a, RelationshipWeb b)
    {
        foreach(CharacterData chr in b.members)
        {
            chr.currentShipWeb = a;
            a.members.Add(chr);
        }

        GameObject.Destroy(b);
    }

    public static void ProcessBreakup(CharacterData a, CharacterData b)
    {
        //TODO: Figure out if relationships need to be split into two
        // if so do the thing

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
        GameObject Relationship = new GameObject();
        Relationship.transform.SetParent(Instance.transform);
        RelationshipWeb web = Relationship.AddComponent<RelationshipWeb>();
        return web;
    }
}
