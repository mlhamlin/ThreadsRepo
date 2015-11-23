using System.Collections.Generic;

public class RelationshipNetwork : UnitySingletonPersistent<RelationshipNetwork> {

    public List<Relationship> Relationships;
    public int CurrentNetHappiness;

    public void Update()
    {
        RecalculateHappiness();
    }

    public static void setVisibleThreadCharacter(Character chr)
    {
        foreach(Relationship ship in Instance.Relationships)
        {
            ship.SetThreadVisibility(ship.Contains(chr));
        }
    }

    public void RecalculateHappiness()
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
