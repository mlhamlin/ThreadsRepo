using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicControl : UnitySingletonPersistent<MusicControl> {

    public AudioMixer InsideMusic;
    public AudioMixer OutsideMusic;
    public AudioMixer OutOfTownMusic;
    public AudioMixer BackgroundSounds;

    static string MUTE = "Mute All";
    static string LEVEL1PROGRESS = "Progress Level 1";
    static string LEVEL2PROGRESS = "Progress Level 2";
    static string LEVEL3PROGRESS = "Progress Level 3";

    static string MAIN_STREET_LEFT = "Main Street Left";
    static string MAIN_STREET_RIGHT = "Main Street Right";
    static string TOWN_CENTER = "Town Center";
    static string BAKERY_KITCHEN = "Bakery Kitchen";
    static string ALIYAS_ROOM = "Aliya's Room";
    static string METAL_WORKS = "Metal Works";
    static string TAVERN = "Tavern";
    static string GENERAL_STORE = "General Store";
    static string FARM = "Farm";


    public static void TransitionLocation(Location Old, Location New)
    {
        SwitchZone(Old.Zone, New.Zone);
        ActivateArea(New.Area);
    }

    public static void SwitchZone(Location.Zones oldZone, Location.Zones newZone)
    {
        Instance.muteZone(oldZone);
        Instance.activateZone(newZone);
    }

    private void activateZone(Location.Zones Zone)
    {
        AudioMixer ActiveMixer = null;

        switch(Zone)
        {
            case Location.Zones.Inside:
                ActiveMixer = InsideMusic;
                break;
            case Location.Zones.OutOfTown:
                ActiveMixer = OutOfTownMusic;
                break;
            case Location.Zones.Outside:
                ActiveMixer = OutsideMusic;
                break;
        }

        switch(RelationshipNetwork.GetHappinessLevel())
        {
            case 1:
                ActiveMixer.FindSnapshot(LEVEL1PROGRESS).TransitionTo(0f);
                break;
            case 2:
                ActiveMixer.FindSnapshot(LEVEL2PROGRESS).TransitionTo(0f);
                break;
            case 3:
                ActiveMixer.FindSnapshot(LEVEL3PROGRESS).TransitionTo(0f);
                break;
        }
    }

    private void muteZone(Location.Zones Zone)
    {
        switch(Zone)
        {
            case Location.Zones.Inside:
                InsideMusic.FindSnapshot(MUTE).TransitionTo(0);
                break;
            case Location.Zones.OutOfTown:
                OutOfTownMusic.FindSnapshot(MUTE).TransitionTo(0);
                break;
            case Location.Zones.Outside:
                OutsideMusic.FindSnapshot(MUTE).TransitionTo(0);
                break;
        }
    }

    public static void ActivateArea(Location.Areas Areas)
    {
        switch(Areas)
        {
            case Location.Areas.AliyaRoom:
                Instance.BackgroundSounds.FindSnapshot(ALIYAS_ROOM).TransitionTo(0);
                return;
            case Location.Areas.Bakery:
                Instance.BackgroundSounds.FindSnapshot(BAKERY_KITCHEN).TransitionTo(0);
                return;
            case Location.Areas.Farm:
                Instance.BackgroundSounds.FindSnapshot(FARM).TransitionTo(0);
                return;
            case Location.Areas.GeneralStore:
                Instance.BackgroundSounds.FindSnapshot(GENERAL_STORE).TransitionTo(0);
                return;
            case Location.Areas.MainStreetLeft:
                Instance.BackgroundSounds.FindSnapshot(MAIN_STREET_LEFT).TransitionTo(0);
                return;
            case Location.Areas.MainStreetRight:
                Instance.BackgroundSounds.FindSnapshot(MAIN_STREET_RIGHT).TransitionTo(0);
                return;
            case Location.Areas.MetalWorks:
                Instance.BackgroundSounds.FindSnapshot(METAL_WORKS).TransitionTo(0);
                return;
            case Location.Areas.Tavern:
                Instance.BackgroundSounds.FindSnapshot(TAVERN).TransitionTo(0);
                return;
            case Location.Areas.TownCenter:
                Instance.BackgroundSounds.FindSnapshot(TOWN_CENTER).TransitionTo(0);
                return;
        }
    }
}
