using UnityEngine;
using System.Collections;

public class TeleportZone : MonoBehaviour
{

    public Vector3 Destination;
    public BoxCollider2D DestinationBounds;


    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player Enter");
        if(other.gameObject.tag == "Player")
        {
            TeleportHandler.Instance.TeleportPlayer(Destination, DestinationBounds);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(Destination, .2f);
        Bounds bound = DestinationBounds.bounds;
        Vector3 min = bound.min;
        Vector3 max = bound.max;

        Gizmos.DrawLine(min, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(min, new Vector3(max.x, min.y, min.z));
        Gizmos.DrawLine(max, new Vector3(min.x, max.y, min.z));
        Gizmos.DrawLine(max, new Vector3(max.x, min.y, min.z));
    }
}
