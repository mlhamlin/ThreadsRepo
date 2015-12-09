using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MusicControl : UnitySingletonPersistent<MusicControl> {

    public AudioMixer InsideMusic;
    public AudioMixer OutsideMusic;
    public AudioMixer OutOfTownMusic;
    public AudioMixer BackgroundSounds;

    private AudioMixer ActiveMusic;

    static float TRANSITION_TIME = 1f;

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
        switch(Zone)
        {
            case Location.Zones.Inside:
                ActiveMusic = InsideMusic;
                break;
            case Location.Zones.OutOfTown:
                ActiveMusic = OutOfTownMusic;
                break;
            case Location.Zones.Outside:
                ActiveMusic = OutsideMusic;
                break;
        }

        setProgressLevel();
    }

    public void setProgressLevel()
    {
        switch(RelationshipNetwork.GetHappinessLevel())
        {
            case 1:
                ActiveMusic.FindSnapshot(LEVEL1PROGRESS).TransitionTo(TRANSITION_TIME);
                break;
            case 2:
                ActiveMusic.FindSnapshot(LEVEL2PROGRESS).TransitionTo(TRANSITION_TIME);
                break;
            case 3:
                ActiveMusic.FindSnapshot(LEVEL3PROGRESS).TransitionTo(TRANSITION_TIME);
                break;
        }
    }

    private void muteZone(Location.Zones Zone)
    {
        switch(Zone)
        {
            case Location.Zones.Inside:
                InsideMusic.FindSnapshot(MUTE).TransitionTo(TRANSITION_TIME);
                break;
            case Location.Zones.OutOfTown:
                OutOfTownMusic.FindSnapshot(MUTE).TransitionTo(TRANSITION_TIME);
                break;
            case Location.Zones.Outside:
                OutsideMusic.FindSnapshot(MUTE).TransitionTo(TRANSITION_TIME);
                break;
        }
    }

    public static void ActivateArea(Location.Areas Areas)
    {
        switch(Areas)
        {
            case Location.Areas.AliyaRoom:
                Instance.BackgroundSounds.FindSnapshot(ALIYAS_ROOM).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.Bakery:
                Instance.BackgroundSounds.FindSnapshot(BAKERY_KITCHEN).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.Farm:
                Instance.BackgroundSounds.FindSnapshot(FARM).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.GeneralStore:
                Instance.BackgroundSounds.FindSnapshot(GENERAL_STORE).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.MainStreetLeft:
                Instance.BackgroundSounds.FindSnapshot(MAIN_STREET_LEFT).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.MainStreetRight:
                Instance.BackgroundSounds.FindSnapshot(MAIN_STREET_RIGHT).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.MetalWorks:
                Instance.BackgroundSounds.FindSnapshot(METAL_WORKS).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.Tavern:
                Instance.BackgroundSounds.FindSnapshot(TAVERN).TransitionTo(TRANSITION_TIME);
                return;
            case Location.Areas.TownCenter:
                Instance.BackgroundSounds.FindSnapshot(TOWN_CENTER).TransitionTo(TRANSITION_TIME);
                return;
        }
    }
}
