using UnityEngine;
using System.Collections;

public class TeleportZone : MonoBehaviour
{

    public Transform Destination;
    public BoxCollider2D DestinationBounds;


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Enter");
        if(other.gameObject.tag == "Player")
        {
            TeleportHandler.Instance.TeleportPlayer(Destination.position, DestinationBounds);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Destination.position, .3f);
        Gizmos.color = Color.yellow;
        Bounds bound = DestinationBounds.bounds;
        Vector3 min = bound.min;
        Vector3 max = bound.max;

        Gizmos.DrawLine(min, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(min, new Vector3(max.x, min.y, min.z));
        Gizmos.DrawLine(max, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(max, new Vector3(max.x, min.y, min.z));
    }
}
