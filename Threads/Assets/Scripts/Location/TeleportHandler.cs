using UnityEngine;
using System.Collections;

public class TeleportHandler : UnitySingletonPersistent<TeleportHandler> {

    public PlayerCamControl CameraController;
    public Transform Player;
    public Location CurrentArea;

    public void TeleportPlayer(Vector3 location, Location destination)
    {
        MusicControl.TransitionLocation(CurrentArea, destination);
        CurrentArea = destination;
        Player.transform.position = location;
        Player.GetComponent<Footsteps>().currentSurface = destination.Surface;
        CameraController.BackgroundBounds = CurrentArea.AreaExternal;
        CameraController.TeleportFollow();
    }
}
