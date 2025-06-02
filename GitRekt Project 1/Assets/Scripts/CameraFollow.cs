using JetBrains.Annotations;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {

        //TODO: ACTUALLY SET THE OFFSET FOR THE CAMERA

        //Calculate the target position based on the player's position and the camera offset
        Vector3 targetPosition = playerTransform.position + offset;

        //smoothly interpolate to that position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }


}