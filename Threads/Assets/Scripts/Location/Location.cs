using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Location : MonoBehaviour
{

    public enum Zones
    {
        Inside, Outside, OutOfTown
    }
    public enum Areas
    {
        Bakery, Tavern, MetalWorks, MainStreetLeft, TownCenter, AliyaRoom, MainStreetRight, GeneralStore, Farm
    }

    public Zones Zone;
    public Areas Area;
    public Footsteps.Surface Surface;

    public BoxCollider2D AreaExternal;
    public List<TeleportZone> exitPoints; //auto gen from children?
    public List<Transform> entryPoints; //auto gen from children?
}
