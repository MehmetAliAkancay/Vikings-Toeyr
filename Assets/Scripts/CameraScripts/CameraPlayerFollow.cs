using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    public GameObject targetObj;
    public Vector3 cameraOffset;
    public Vector3 targetedPosition;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.25f;
    void LateUpdate()
    {
        targetedPosition = targetObj.transform.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
    }
}
