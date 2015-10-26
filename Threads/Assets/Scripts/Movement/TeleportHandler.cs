using UnityEngine;
using System.Collections;

public class TeleportHandler : UnitySingletonPersistent<TeleportHandler> {

    public PlayerCamControl CameraController;
    public Transform Player;

    public void TeleportPlayer(Vector3 destination, BoxCollider2D newBounds)
    {
        Player.transform.position = destination;
        CameraController.BackgroundBounds = newBounds;
        CameraController.TeleportFollow();
    }

}
