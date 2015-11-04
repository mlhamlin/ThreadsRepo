using System.Collections.Generic;

public class RelationshipNetwork : UnitySingletonPersistent<RelationshipNetwork> {

    public List<Relationship> Relationships;
    public int CurrentNetHappiness;

    //Sets if the character "shipper" is shipping themselves with "shipee"
    public static void SetCharacterInterested(Character shipper, Character shipee, bool shippingIt)
    {
        foreach(Relationship ship in Instance.Relationships)
        {
            if (ship.Contains(shipper, shipee))
            {
                ship.SetShippingIt(shipper, shippingIt);
            }
        }

        Instance.recalculateHappiness();
    }

    public static void setVisibleThreadCharacter(Character chr)
    {
        foreach(Relationship ship in Instance.Relationships)
        {
            ship.SetThreadVisibility(ship.Contains(chr));
        }
    }

    private void recalculateHappiness()
    {
        CurrentNetHappiness = 0;

        foreach(Relationship ship in Relationships)
        {
            if(ship.Canon)
            {
                CurrentNetHappiness += ship.Quality;
            }
        }
    } 
}
