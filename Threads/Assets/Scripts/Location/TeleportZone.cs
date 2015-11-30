using UnityEngine;
using System.Collections;

public class TeleportZone : MonoBehaviour
{
    public Location Destination;

    [HideInInspector][SerializeField]
    private int selectedLoc;
    [HideInInspector][SerializeField]
    private Transform EntryLocation;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            TeleportHandler.Instance.TeleportPlayer(EntryLocation.position, Destination);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(EntryLocation.position, .3f);
        Gizmos.DrawLine(transform.position, EntryLocation.position);

        Gizmos.color = Color.yellow;
        Bounds bound = Destination.AreaExternal.bounds;
        Vector3 min = bound.min;
        Vector3 max = bound.max;
        Gizmos.DrawLine(min, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(min, new Vector3(max.x, min.y, min.z));
        Gizmos.DrawLine(max, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(max, new Vector3(max.x, min.y, min.z));
    }

    public int getSelectedIndex()
    {
        return selectedLoc;
    }

    public void setEntryLocation(int selected, Transform loc)
    {
        selectedLoc = selected;
        EntryLocation = loc;
    }
}
