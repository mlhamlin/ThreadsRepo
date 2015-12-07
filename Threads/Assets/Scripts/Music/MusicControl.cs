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

    static string MAIN_STREET_LEFT;
    static string MAIN_STREET_RIGHT;
    static string CITY_CENTER;
    static string BAKERY_KITCHEN;
    static string ALIYAS_ROOM;
    static string METAL_WORKS;
    static string TAVERN;
    static string GENERAL_STORE;


    public static void TransitionLocation(Location Old, Location New)
    {
        SwitchZone(Old.Zone, New.Zone);
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

    public void SwitchArea()
    {

    }
}
