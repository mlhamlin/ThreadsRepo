using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Location : MonoBehaviour
{

    public enum Zones
    {
        Inside, Outside, OutOfTown
    }
    public enum Locations
    {
        Bakery, Tavern, MetalWorks, MainStreetLeft, TownCenter, AliyaRoom, MainStreetRight
    }

    public Zones Zone;
    public Locations LocEnum;
    public BoxCollider2D AreaExternal;
    //background music
    //background sounds
    public bool active;
    public List<TeleportZone> exitPoints; //auto gen from children?
    public List<Transform> entryPoints; //auto gen from children?

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLocationActive(bool act)
    {
    }
}
