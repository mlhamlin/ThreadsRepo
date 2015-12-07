using System.Collections.Generic;

public class RelationshipNetwork : UnitySingletonPersistent<RelationshipNetwork> {

    public List<Relationship> Relationships;
    public int CurrentNetHappiness;

    const int LEVEL2THRESHOLD = 10;
    const int LEVEL3THRESHOLD = 20;

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

    public static int GetHappinessLevel()
    {
        if (Instance.CurrentNetHappiness < LEVEL2THRESHOLD)
        {
            return 1;
        } else if (Instance.CurrentNetHappiness < LEVEL3THRESHOLD)
        {
            return 2;
        } else
        {
            return 3;
        }
    }
}
