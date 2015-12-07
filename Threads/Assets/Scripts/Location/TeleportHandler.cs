using UnityEngine;
using System.Collections;

public class TeleportHandler : UnitySingletonPersistent<TeleportHandler> {

    public PlayerCamControl CameraController;
    public Transform Player;
    public Location CurrentArea;

    public void TeleportPlayer(Vector3 location, Location destination)
    {
        CurrentArea.active = false;
        //TODO: Improve
        MusicControl.TransitionLocation(CurrentArea, destination);
        CurrentArea = destination;
        CurrentArea.active = true;
        Player.transform.position = location;
        CameraController.BackgroundBounds = CurrentArea.AreaExternal;
        CameraController.TeleportFollow();
    }
}
