using UnityEngine;
using System.Collections;

public class DropPlayerBack : MonoBehaviour {

    public int Layer;
    int oldLayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpriteRenderer rend = other.gameObject.GetComponent<SpriteRenderer>();
            if(rend != null)
            {
                oldLayer = rend.sortingOrder;
                rend.sortingOrder = Layer;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            SpriteRenderer rend = other.gameObject.GetComponent<SpriteRenderer>();
            if(rend != null)
            { 
                rend.sortingOrder = oldLayer;
            }
        }
    }
}
