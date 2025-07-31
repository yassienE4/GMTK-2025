using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    public float xFollowSpeed = 5f;
    public float yFollowSpeed = 2f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = target.position + offset;

            float newX = Mathf.Lerp(currentPosition.x, targetPosition.x, xFollowSpeed * Time.deltaTime);
            float newY = Mathf.Lerp(currentPosition.y, targetPosition.y, yFollowSpeed * Time.deltaTime);

            transform.position = new Vector3(newX, newY, targetPosition.z);
        }
    }
}
