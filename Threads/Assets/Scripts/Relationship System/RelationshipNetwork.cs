using System.Collections.Generic;

public class RelationshipNetwork : UnitySingletonPersistent<RelationshipNetwork> {

    public int CurrentNetHappiness;
    private int OldNetHappiness;

    private List<Relationship> Relationships;
    const int LEVEL2THRESHOLD = 15;
    const int LEVEL3THRESHOLD = 35;

    public override void Awake()
    {
        OnAwake();
        Relationships = new List<Relationship>();
    }

    public static void RegisterRelationship(Relationship ship)
    {
        if(!Instance.Relationships.Contains(ship))
        {
            Instance.Relationships.Add(ship);
        }

        Instance.RecalculateHappiness();
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
        OldNetHappiness = CurrentNetHappiness;
        CurrentNetHappiness = 0;

        foreach(Relationship ship in Relationships)
        {
            if(ship.Canon)
            {
                CurrentNetHappiness += ship.Quality;
            }
        }

        if (OldNetHappiness != CurrentNetHappiness)
        {
            MusicControl.Instance.setProgressLevel();
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
