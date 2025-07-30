using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // Assign your player here
    public Vector3 offset = new Vector3(0, 0, -10); // Camera offset from the player
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }
}
