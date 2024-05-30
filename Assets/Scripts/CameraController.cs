using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Player player;

    public void SwitchToStartPosition()
    {
        transform.parent = null;
        transform.position = Game.StartCameraPostion.position;
        transform.rotation = Game.StartCameraPostion.rotation;
    }

    public void SwitchToPlayer()
    {
        transform.parent = player.CameraSocket;
        transform.localEulerAngles = Vector3.zero;
        transform.localPosition = Vector3.zero;
    }
}
